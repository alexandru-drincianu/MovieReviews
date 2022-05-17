import 'dart:async';
import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

String URL = 'https://5709-5-14-159-17.eu.ngrok.io/movies.json';

Future<List<Movie>> fetchMoviesList() async {
  final response = await http.get(Uri.parse(URL));
  if (response.statusCode == 200) {
    List jsonResponse = json.decode(response.body);
    return jsonResponse.map((data) => Movie.fromJson(data)).toList();
  } else {
    throw Exception('Unexpected error occured!');
  }
}

class Movie {
  final int id;
  final String title;
  final String description;
  final String moviePicture;
  final String year;
  final String duration;
  final String genres;

  const Movie(
      {required this.id,
      required this.title,
      required this.description,
      required this.moviePicture,
      required this.year,
      required this.duration,
      required this.genres});

  factory Movie.fromJson(Map<String, dynamic> json) {
    return Movie(
        id: json['id'],
        title: json['title'],
        description: json['description'],
        moviePicture: json['moviePicture'],
        year: json['year'],
        duration: json['duration'],
        genres: json['genres']);
  }
}
