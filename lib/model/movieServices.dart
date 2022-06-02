import 'dart:async';
import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

String URL = 'https://10.0.2.2:7147/api/Movies/all';

Future<List<Movie>> fetchMoviesList() async {
  final response = await http.get(Uri.parse(URL));
  if (response.statusCode == 200) {
    List jsonResponse = json.decode(response.body);
    return jsonResponse.map((data) => Movie.fromJson(data)).toList();
  } else {
    throw Exception('Unexpected error occured!');
  }
}

Future<Movie> getMovieById(int movieId) async {
  final response = await http
      .get(Uri.parse('https://jsonplaceholder.typicode.com/albums/$movieId'));

  if (response.statusCode == 200) {
    // If the server did return a 200 OK response,
    // then parse the JSON.
    return Movie.fromJson(jsonDecode(response.body));
  } else {
    // If the server did not return a 200 OK response,
    // then throw an exception.
    throw Exception('Failed to load album');
  }
}

class Movie {
  final int id;
  final String title;
  final String description;
  final String moviePicture;
  // final String year;
  // final String duration;
  final List<dynamic> genres;
  final List<dynamic> reviews;
  final List<dynamic> actors;

  const Movie(
      {required this.id,
      required this.title,
      required this.description,
      required this.moviePicture,
      //required this.year,
      //required this.duration,
      required this.genres,
      required this.reviews,
      required this.actors});

  factory Movie.fromJson(Map<String, dynamic> json) {
    return Movie(
        id: json['id'],
        title: json['title'],
        description: json['description'],
        moviePicture: json['moviePicture'],
        //year: json['year'],
        //duration: json['duration'],
        genres: json['genres'],
        reviews: json['reviews'],
        actors: json['actors']);
  }
}
