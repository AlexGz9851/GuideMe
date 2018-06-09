from django.shortcuts import render
from django.http import HttpResponse, JsonResponse
from django.shortcuts import render, Http404, redirect, reverse
from server.is_post import is_not_post_raise404
from django.views.decorators.csrf import csrf_exempt

# def index(request):
#     if is_post(request):
#         return JsonResponse({"request":"location_manager"})
#     raise Http404

@csrf_exempt
def place_search(request):
    is_not_post_raise404(request)    
    # Request to google
    # Create session variable
    return obtain_locations_page(1)
    

@csrf_exempt
def obtain_locations(request):
    is_not_post_raise404(request)
    return obtain_locations_page(request.POST['page'])
    

@csrf_exempt
def save_travel(request):
    is_not_post_raise404(request)
    # remove session variable
    # save to database
    return JsonResponse({"ok":"ok"})
    

def obtain_locations_page(page_number):
    # Create pagination algorithm over the session variable
    return JsonResponse({"places":{"1":"data1","2":"data2","3":"data3","4":"data4"}})
    