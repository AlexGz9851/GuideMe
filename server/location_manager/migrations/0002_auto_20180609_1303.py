# Generated by Django 2.0.1 on 2018-06-09 18:03

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('location_manager', '0001_initial'),
    ]

    operations = [
        migrations.AddField(
            model_name='location',
            name='coordinates',
            field=models.CharField(default='', max_length=50),
        ),
        migrations.AddField(
            model_name='location',
            name='icon',
            field=models.CharField(default='', max_length=255),
        ),
        migrations.AddField(
            model_name='location',
            name='name',
            field=models.CharField(default='', max_length=50),
        ),
        migrations.AddField(
            model_name='location',
            name='place_id',
            field=models.CharField(default='', max_length=255),
        ),
        migrations.AddField(
            model_name='location',
            name='rating',
            field=models.FloatField(default=0),
        ),
        migrations.AddField(
            model_name='travel',
            name='name',
            field=models.CharField(default='', max_length=100),
        ),
    ]
