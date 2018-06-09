from django.shortcuts import render
from django.http import HttpResponse,JsonResponse
from django.shortcuts import render, Http404, redirect, reverse
from server.is_post import is_not_post_raise404
from django.views.decorators.csrf import csrf_exempt
from .models import User, Tag

# def index(request):
#     if is_post(request):
#         return JsonResponse({"request":"user_manager"})
#     raise Http404

@csrf_exempt
def login(request):
    is_not_post_raise404(request)
    try:
        user = User.objects.get(social_network_user_id=request.POST['social_network_user_id'],social_network_id=request.POST['social_network_id'])
    except User.DoesNotExist:
        user = User(social_network_user_id=empty_string_is_null(request.POST['social_network_user_id']), social_network_id=empty_string_is_null(request.POST['social_network_id']), token=empty_string_is_null(request.POST['token']))
        # Add the facebook graph implementation
        # TODO Add here the implementation to obtain the tags from the machine learning API
        user.save()
        tags = list(Tag.objects.values_list('id', flat=True))
        for tag in tags:
            user.tags.add(Tag.objects.get(id=tag))
        
    return JsonResponse({"social_network_user_id":user.social_network_user_id, "token":user.token, "social_network_id":user.social_network_id})
    

@csrf_exempt
def logout(request):
    is_not_post_raise404(request)
    user = User.objects.get(id=request.POST['id'])
    user.token = None
    user.save()
    return JsonResponse({"id":request.POST['id']})
    
def empty_string_is_null(string):
    return (None if string == "" else string)