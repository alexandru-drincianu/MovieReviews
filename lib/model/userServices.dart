import 'dart:async';
import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:movie_reviews_app/screens/LoginPage.dart';

import 'movieServices.dart';

Future<User?> logInUser(String email, String password) async {
  final response = await http.post(
    Uri.parse("https://10.0.2.2:7147/api/auth/login"),
    headers: <String, String>{
      'Content-Type': 'application/json; charset=UTF-8',
    },
    body: jsonEncode(<String, String>{'email': email, 'password': password}),
  );

  if (response.statusCode == 200) {
    isLoggedIn = true;
    return User.fromJson(jsonDecode(response.body));
  } else {
    return null;
  }
}

dynamic createUser(String name, String email, String password) async {
  final response = await http.post(
    Uri.parse("https://10.0.2.2:7147/api/auth/register"),
    headers: <String, String>{
      'Content-Type': 'application/json; charset=UTF-8',
    },
    body: jsonEncode(
        <String, String>{'name': name, 'email': email, 'password': password}),
  );

  if (response.statusCode == 201) {
    // If the server did return a 201 CREATED response,
    // then parse the JSON.
    return response.body;
  } else {
    // If the server did not return a 201 CREATED response,
    // then throw an exception.
    throw Exception('Failed to create user.');
  }
}

dynamic addToFavorite(String userId, int movieId) async {
  final response = await http.put(
    Uri.parse("https://10.0.2.2:7147/api/Favourites/add"),
    headers: <String, String>{
      'Content-Type': 'application/json; charset=UTF-8',
    },
    body: jsonEncode(<String, dynamic>{'userId': userId, 'movieId': movieId}),
  );

  if (response.statusCode == 200) {
    // If the server did return a 200 OK response,
    // then parse the JSON.
    return response.body;
  } else {
    // If the server did not return a 200 OK response,
    // then throw an exception.
    throw Exception('Failed to add favorite.');
  }
}

dynamic removeFromFavorite(String userId, int movieId) async {
  final response = await http.put(
    Uri.parse("https://10.0.2.2:7147/api/Favourites/delete"),
    headers: <String, String>{
      'Content-Type': 'application/json; charset=UTF-8',
    },
    body: jsonEncode(<String, dynamic>{'userId': userId, 'movieId': movieId}),
  );

  if (response.statusCode == 200) {
    // If the server did return a 200 OK response,
    // then parse the JSON.
    return response.body;
  } else {
    // If the server did not return a 200 OK response,
    // then throw an exception.
    throw Exception('Failed to remove favorite.');
  }
}

Future<List<Movie>> getUserFavorites(String userId) async {
  final response =
      await http.get(Uri.parse("https://10.0.2.2:7147/api/Favourites/$userId"));
  if (response.statusCode == 200) {
    List jsonResponse = json.decode(response.body);
    return jsonResponse.map((data) => Movie.fromJson(data)).toList();
  } else {
    throw Exception('Unexpected error occured!');
  }
}

class User {
  final String id;
  final String name;
  final String email;
  final String password;

  const User(
      {required this.id,
      required this.name,
      required this.email,
      required this.password});

  factory User.fromJson(Map<String, dynamic> json) {
    return User(
        id: json['id'],
        name: json['name'],
        email: json['email'],
        password: json['password']);
  }
}
