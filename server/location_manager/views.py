import requests
import json
from random import shuffle
from django.shortcuts import render
from django.http import HttpResponse, JsonResponse
from django.shortcuts import render, Http404, redirect, reverse
from server.is_post import is_not_post_raise404
from django.views.decorators.csrf import csrf_exempt
from server.keys import google_api
from user_manager.models import User
from location_manager.models import Location
from location_manager.models import Travel

# def index(request):
#     if is_post(request):
#         return JsonResponse({"request":"location_manager"})
#     raise Http404

@csrf_exempt
def place_search(request):
    is_not_post_raise404(request)
    user = User.objects.get(id=request.POST['id'])
    results = []
    for tag in user.tags.all():
        # Request to google
        results += requests.get("https://maps.googleapis.com/maps/api/place/search/json", 
                     params = {
                         'key':google_api,
                         'location':request.POST['coordinates'], 
                         'radius':50000, 
                         'rankby':'prominence', 
                         'type':tag.name}
                         ).json()["results"]
    shuffle(results)
    pages = len(results)//10
    request.session['results'] = results
    return obtain_locations_page(request, 1)
    

@csrf_exempt
def obtain_locations(request):
    is_not_post_raise404(request)
    return obtain_locations_page(request, int(request.POST['page']))
    

@csrf_exempt
def save_travel(request):
    is_not_post_raise404(request)
    
    t = Travel(id_user=request.POST['id'], name=request.POST['name'], start=request.POST['start'], end=request.POST['end'])
    t.save()
    for location in request.session['results']:
        if(location['place_id'] in request.POST.get('selected_places')):
            l = Location(
                         id_travel=t.id, 
                         name=location['name'], 
                         coordinates=str(location['geometry']['location']['lat'])+','+str(location['geometry']['location']['lng']),
                         place_id=location['place_id'],
                         icon=location['icon'],
                         rating=location['rating']
                        )
            l.save()
    request.session['results'] = []
    return JsonResponse({"ok":request.POST.get('selected_places')})
    

def obtain_locations_page(request, page):
    if 'results' in request.session:
        page_size = 10
        elements = len(request.session['results'])
        pages = elements // page_size
        start = (page-1)*page_size
        end = start+10 if start+10<elements else elements
        results = request.session['results'][start:end]
        return JsonResponse({'results':results, 'pages':pages, 'page':page, 'element':elements})
    raise Http404
    