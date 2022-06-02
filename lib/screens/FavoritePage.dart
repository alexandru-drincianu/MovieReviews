// ignore_for_file: prefer_const_constructors

import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:movie_reviews_app/model/userServices.dart';
import 'package:movie_reviews_app/screens/LoginPage.dart';
import 'package:movie_reviews_app/screens/SortedPage.dart';
import '../model/genreServices.dart';
import '../model/movieServices.dart';
import '../screens/DetailPage.dart';
import '../custom/BorderIcon.dart';
import '../custom/OptionButton.dart';
import '../utils/constants.dart';
import '../utils/custom_functions.dart';
import '../utils/widget_functions.dart';
import '../widgets/nav-drawer.dart';

class FavoritePage extends StatefulWidget {
  const FavoritePage({Key? key}) : super(key: key);

  @override
  _FavoritePageState createState() => _FavoritePageState();
}

class _FavoritePageState extends State<FavoritePage> {
  late Future<List<Genre>> futureGenre;
  late Future<List<Movie>> futureFavoriteMovie;

  late List<Movie> _favorite = [];
  late List<Genre> _genres = [];

  List<Movie> getMovies() {
    return _favorite;
  }

  @override
  void initState() {
    futureFavoriteMovie = getUserFavorites(loggedInUser.id);
    futureFavoriteMovie.then((movies) {
      setState(() {
        _favorite = movies;
      });
    });

    futureGenre = fetchGenresList();
    futureGenre.then((genres) {
      setState(() {
        _genres = genres;
      });
    });

    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    final Size size = MediaQuery.of(context).size;
    final ThemeData themeData = Theme.of(context);
    double padding = 25;
    final sidePadding = EdgeInsets.symmetric(horizontal: padding);

    return Scaffold(
      drawer: NavDrawer(),
      appBar: AppBar(
        backgroundColor: Colors.black87,
      ),
      body: SizedBox(
        width: size.width,
        height: size.height,
        child: Stack(
          children: [
            Column(
              mainAxisSize: MainAxisSize.min,
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                addVerticalSpace(10),
                Padding(
                  padding: sidePadding,
                  child: Text(
                    "Movies",
                    style: themeData.textTheme.headline1,
                  ),
                ),
                Padding(
                    padding: sidePadding,
                    child: Divider(
                      height: 25,
                      color: COLOR_GREY,
                    )),
                Expanded(
                  child: Padding(
                    padding: sidePadding,
                    child: ListView.builder(
                        physics: BouncingScrollPhysics(),
                        itemCount: _favorite.length,
                        itemBuilder: (context, index) {
                          return MovieItem(
                            itemData: _favorite[index],
                            key: null,
                          );
                        }),
                  ),
                ),
              ],
            ),
          ],
        ),
      ),
    );
  }
}

class MovieItem extends StatelessWidget {
  final dynamic itemData;

  const MovieItem({Key? key, this.itemData}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    final ThemeData themeData = Theme.of(context);
    String allGenres = "";
    for (var sub in itemData.genres) {
      allGenres = allGenres + sub['genreName'];
    }

    var movieImage = itemData.moviePicture.split(",");

    return GestureDetector(
      onTap: () {
        Navigator.of(context).push(MaterialPageRoute(
            builder: (context) => DetailPage(
                  itemData: itemData,
                )));
      },
      child: Container(
        margin: const EdgeInsets.symmetric(vertical: 25),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Stack(
              children: [
                ClipRRect(
                    borderRadius: BorderRadius.circular(25.0),
                    child: Image.memory(base64.decode(movieImage[1]))),
              ],
            ),
            addVerticalSpace(15),
            Row(
              children: [
                Text(
                  "${itemData.title}",
                  style: themeData.textTheme.headline1,
                ),
                addHorizontalSpace(10),
                // Text(
                //   "${itemData.year}",
                //   style: themeData.textTheme.bodyText2,
                // )
              ],
            ),
            addVerticalSpace(10),
            Text(
              "$allGenres | ${itemData.title}",
              style: themeData.textTheme.headline5,
            )
          ],
        ),
      ),
    );
  }
}
