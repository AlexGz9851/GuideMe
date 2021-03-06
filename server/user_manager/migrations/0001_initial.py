# Generated by Django 2.0.1 on 2018-06-09 06:23

from django.db import migrations, models
import uuid


class Migration(migrations.Migration):

    initial = True

    dependencies = [
    ]

    operations = [
        migrations.CreateModel(
            name='SocialNetwork',
            fields=[
                ('id', models.UUIDField(default=uuid.uuid4, primary_key=True, serialize=False, unique=True)),
                ('name', models.CharField(max_length=20)),
            ],
        ),
        migrations.CreateModel(
            name='Tag',
            fields=[
                ('id', models.UUIDField(default=uuid.uuid4, primary_key=True, serialize=False, unique=True)),
                ('name', models.CharField(max_length=20)),
            ],
        ),
        migrations.CreateModel(
            name='User',
            fields=[
                ('id', models.UUIDField(default=uuid.uuid4, primary_key=True, serialize=False, unique=True)),
                ('social_network_id', models.PositiveIntegerField(null=True)),
                ('social_network_user_id', models.CharField(max_length=500, null=True)),
                ('token', models.CharField(max_length=500, null=True)),
                ('tags', models.ManyToManyField(to='user_manager.Tag')),
            ],
        ),
    ]
