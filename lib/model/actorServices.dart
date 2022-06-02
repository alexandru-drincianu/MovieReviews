import 'dart:async';
import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

String URL = 'https://10.0.2.2:7147/api/Actors';

Future<List<Actor>> fetchActorList() async {
  final response = await http.get(Uri.parse(URL));
  if (response.statusCode == 200) {
    List jsonResponse = json.decode(response.body);
    return jsonResponse.map((data) => Actor.fromJson(data)).toList();
  } else {
    throw Exception('Unexpected error occured!');
  }
}

class Actor {
  final int id;
  final String name;
  final String image;

  const Actor({
    required this.id,
    required this.name,
    required this.image,
  });

  factory Actor.fromJson(Map<String, dynamic> json) {
    return Actor(id: json['id'], name: json['name'], image: json['image']);
  }
}
