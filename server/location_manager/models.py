from django.db import models
import uuid

class Travel(models.Model):
    """
        This model describes the User travels
    """
    id = models.UUIDField(primary_key=True, default=uuid.uuid4, unique=True)
    name = models.CharField(max_length=100, default='')
    id_user = models.CharField(max_length=500, default='')
    start = models.DateField()
    end = models.DateField()


class Location(models.Model):
    """
        This model describes the locations an user has visited
    """
    id = models.UUIDField(primary_key=True, default=uuid.uuid4, unique=True)
    id_travel = models.CharField(max_length=500, default='')
    name = models.CharField(max_length=50, default='')
    coordinates = models.CharField(max_length=50, default='')
    place_id = models.CharField(max_length=255, default='')
    icon = models.CharField(max_length=255, default='')
    rating = models.FloatField(default=0)