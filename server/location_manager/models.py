from django.db import models
import uuid

class Travel(models.Model):
    """
        This model describes the User travels
    """
    id = models.UUIDField(primary_key=True, default=uuid.uuid4, unique=True)
    id_user = models.IntegerField()
    start = models.DateField()
    end = models.DateField()


class Location(models.Model):
    """
        This model describes the locations an user has visited
    """
    id = models.UUIDField(primary_key=True, default=uuid.uuid4, unique=True)
    id_travel = models.IntegerField()