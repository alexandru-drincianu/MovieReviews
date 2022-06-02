import 'dart:async';
import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

Future<List<Review>> fetchReviewsList() async {
  final response =
      await http.get(Uri.parse('https://10.0.2.2:7147/api/Reviews'));
  if (response.statusCode == 200) {
    List jsonResponse = json.decode(response.body);
    return jsonResponse.map((data) => Review.fromJson(data)).toList();
  } else {
    throw Exception('Unexpected error occured!');
  }
}

Future<Review> createReview(
    String userId, int movieId, double rating, String description) async {
  final response = await http.post(
    Uri.parse("https://10.0.2.2:7147/api/Reviews"),
    headers: <String, String>{
      'Content-Type': 'application/json; charset=UTF-8',
    },
    body: jsonEncode(<String, dynamic>{
      'userId': userId,
      'movieId': movieId,
      'rating': rating,
      'description': description
    }),
  );

  if (response.statusCode == 201) {
    // If the server did return a 201 CREATED response,
    // then parse the JSON.
    return Review.fromJson(jsonDecode(response.body));
  } else {
    // If the server did not return a 201 CREATED response,
    // then throw an exception.
    throw Exception('Failed to create review.');
  }
}

Future<Review> updateReview(String userId, int movieId, double rating,
    String description, int reviewId) async {
  final response = await http.put(
    Uri.parse("https://10.0.2.2:7147/api/Reviews/$reviewId"),
    headers: <String, String>{
      'Content-Type': 'application/json; charset=UTF-8',
    },
    body: jsonEncode(<String, dynamic>{
      'userId': userId,
      'movieId': movieId,
      'rating': rating,
      'description': description
    }),
  );

  if (response.statusCode == 200) {
    // If the server did return a 200 OK response,
    // then parse the JSON.
    return Review.fromJson(jsonDecode(response.body));
  } else {
    // If the server did not return a 200 OK response,
    // then throw an exception.
    throw Exception('Failed to update reviews.');
  }
}

class Review {
  final int id;
  final int movieId;
  final String userId;
  final String userName;
  final int rating;
  final String description;

  const Review(
      {required this.id,
      required this.movieId,
      required this.userId,
      required this.userName,
      required this.rating,
      required this.description});

  factory Review.fromJson(Map<String, dynamic> json) {
    return Review(
        id: json['id'],
        movieId: json['movieId'],
        userId: json['userId'],
        userName: json['userName'],
        rating: json['rating'],
        description: json['description']);
  }
}
