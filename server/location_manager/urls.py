from django.urls import path

from . import views

urlpatterns = [
    # path('', views.index, name='index'),
    path('place_search', views.place_search, name='place_search'),
    path('obtain_locations', views.obtain_locations, name='obtain_locations'),
    path('save_travel', views.save_travel, name='save_travel'),   
]