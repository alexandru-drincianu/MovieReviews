import 'dart:async';
import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

String URL = 'https://10.0.2.2:7147/api/Genres';

Future<List<Genre>> fetchGenresList() async {
  final response = await http.get(Uri.parse(URL));
  if (response.statusCode == 200) {
    List jsonResponse = json.decode(response.body);
    return jsonResponse.map((data) => Genre.fromJson(data)).toList();
  } else {
    throw Exception('Unexpected error occured!');
  }
}

class Genre {
  final int id;
  final String genreName;
  final List<dynamic> movies;

  const Genre({
    required this.id,
    required this.genreName,
    required this.movies,
  });

  factory Genre.fromJson(Map<String, dynamic> json) {
    return Genre(
        id: json['id'], genreName: json['genreName'], movies: json['movies']);
  }
}
