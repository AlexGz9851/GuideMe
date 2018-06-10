#!/usr/bin/python3
from flask import Flask, request, jsonify
from flask_restful import Resource, Api
from json import dumps
import requests
import os
import operator
from scripts.label_image import main

app = Flask(__name__)
api = Api(app)

CLAVES = {
    "0": "Acquiarium",
    "1": "AmusementPark",
    "2": "ArtGallery",
    "3": "Bar",
    "4": "BeautySalon",
    "5": "Cafe",
    "6": "CampGround",
    "7": "Casino",
    "8": "Church",
    "9": "CityHall",
    "10": "HinduTemple",
    "11": "MovieTheater",
    "12": "Museum",
    "13": "NigthClub",
    "14": "Park",
    "15": "Restaurant",
    "16": "ShoppingMall",
    "17": "Spa",
    "18": "Stadium",
    "19": "Zoo"
}

class ImageData(Resource):
    def post(self):
        Images = request.json['photos']
        DataSetFinal = {}
        for Image in Images:
            url = Image
            requestImage = requests.get(url)
            with open('./tmp/tmp.jpg', 'wb') as f:
                f.write(requestImage.content)
                f.close()
                results = main("tmp/tmp.jpg")
                try:
                    for key in results:
                        if key in DataSetFinal:
                            prevValue = DataSetFinal.pop(key)
                            newValue = prevValue + results[key]
                            DataSetFinal.update({key: newValue})
                        else:
                            DataSetFinal.setdefault(key, results[key])
                except KeyError:
                    pass
                os.remove("tmp/tmp.jpg")
        resultado = sorted(DataSetFinal.items(), key=operator.itemgetter(1))
        print (resultado)
        resultado = resultado[::-1]
        resultado = resultado[:5]
        
        return {'status': 'success'}

api.add_resource(ImageData, '/')

if __name__ == '__main__':
     app.run()
