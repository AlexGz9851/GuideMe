from django.shortcuts import render
from django.http import HttpResponse,JsonResponse
from django.shortcuts import render, Http404, redirect, reverse
from server.is_post import is_not_post_raise404
from django.views.decorators.csrf import csrf_exempt

# def index(request):
#     if is_post(request):
#         return JsonResponse({"request":"user_manager"})
#     raise Http404

@csrf_exempt
def login(request):
    is_not_post_raise404(request)
    #If is in database the social network user id and social network id return the user data
    #If not request to the social network graph api for the user info-photos and submit them to watson to obtain the user tags
    return JsonResponse({"social_network_user_id":request.POST['social_network_user_id'], "token":request.POST['token'], "social_network_id":request.POST['social_network_id']})
    

@csrf_exempt
def logout(request):
    is_not_post_raise404(request)
    # Remove from database the token of the user
    return JsonResponse({"id":request.POST['id']})
    