from django.shortcuts import Http404

def is_post(request):
    return request.method=='POST'

def is_not_post_raise404(request):
    if not is_post(request):
        raise Http404