from django.shortcuts import render
from django.http import HttpResponse, JsonResponse
from django.shortcuts import render, Http404, redirect, reverse

# Create your views here.
def index(request):
    if request.method == 'POST':
        return JsonResponse({"request":"location_manager"})
    else:
        raise Http404
    
