// ignore_for_file: prefer_const_constructors

import 'dart:typed_data';

import 'package:flutter/material.dart';
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
import 'dart:convert';

class LandingPage extends StatefulWidget {
  const LandingPage({Key? key}) : super(key: key);

  @override
  _LandingPageState createState() => _LandingPageState();
}

class _LandingPageState extends State<LandingPage> {
  late Future<List<Movie>> futureMovie;
  late Future<List<Genre>> futureGenre;

  late List<Movie> _movies = [];
  late List<Genre> _genres = [];

  List<Movie> getMovies() {
    return _movies;
  }

  @override
  void initState() {
    futureMovie = fetchMoviesList();
    futureMovie.then((movies) {
      setState(() {
        _movies = movies;
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
                SizedBox(
                  height: 60,
                  child: ListView.builder(
                      physics: BouncingScrollPhysics(),
                      scrollDirection: Axis.horizontal,
                      shrinkWrap: true,
                      itemCount: _genres.length,
                      itemBuilder: (context, index) {
                        return GenreItem(
                          itemData: _genres[index],
                          key: null,
                        );
                      }),
                ),
                Expanded(
                  child: Padding(
                    padding: sidePadding,
                    child: ListView.builder(
                        physics: BouncingScrollPhysics(),
                        itemCount: _movies.length,
                        itemBuilder: (context, index) {
                          return MovieItem(
                            itemData: _movies[index],
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

class ChoiceOption extends StatelessWidget {
  final dynamic itemData;
  final String text;

  const ChoiceOption({Key? key, required this.itemData, required this.text})
      : super(key: key);

  @override
  Widget build(BuildContext context) {
    final ThemeData themeData = Theme.of(context);
    return Container(
      padding: const EdgeInsets.symmetric(horizontal: 5, vertical: 3),
      margin: const EdgeInsets.only(left: 8),
      child: TextButton(
        onPressed: () {
          Navigator.of(context).push(MaterialPageRoute(
              builder: (context) => SortedPage(
                    itemData: itemData.movies,
                  )));
        },
        style: TextButton.styleFrom(
          backgroundColor: COLOR_GREY.withAlpha(25),
          padding: EdgeInsets.symmetric(horizontal: 15, vertical: 15),
        ),
        child: Text(text, style: themeData.textTheme.headline4),
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
      // ignore: prefer_interpolation_to_compose_strings
      allGenres = "$allGenres " + sub['genreName'];
    }

    var image = itemData.moviePicture.split(",");

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
                    child: Image.memory(base64.decode(image[1]))),
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
              allGenres,
              style: themeData.textTheme.headline5,
            )
          ],
        ),
      ),
    );
  }
}

class GenreItem extends StatelessWidget {
  final dynamic itemData;

  const GenreItem({Key? key, this.itemData}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    final ThemeData themeData = Theme.of(context);
    return GestureDetector(
      onTap: () {},
      child: SingleChildScrollView(
        scrollDirection: Axis.horizontal,
        physics: BouncingScrollPhysics(),
        child: Row(
          children: [itemData.genreName]
              .map((filter) => ChoiceOption(
                    text: filter,
                    itemData: itemData,
                  ))
              .toList(),
        ),
      ),
    );
  }
}
