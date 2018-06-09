from django.db import models
import uuid

class SocialNetwork(models.Model):
    """
        This model describes the social networks options to login
    """
    id = models.UUIDField(primary_key=True, default=uuid.uuid4, unique=True)
    name = models.CharField(max_length=20)

class Tag(models.Model):
    """
        This model describes the tag of an user
    """
    id = models.UUIDField(primary_key=True, default=uuid.uuid4, unique=True)
    name = models.CharField(max_length=20)

class User(models.Model):
    """
        This model describes an user
    """
    id = models.UUIDField(primary_key=True, default=uuid.uuid4, unique=True)
    social_network_id = models.PositiveIntegerField(null=True)
    social_network_user_id = models.CharField(max_length=500, null=True)
    token = models.CharField(max_length=500, null=True)
    tags = models.ManyToManyField(Tag)