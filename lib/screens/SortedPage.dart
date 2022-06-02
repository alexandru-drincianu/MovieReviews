// ignore_for_file: prefer_const_constructors

import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:movie_reviews_app/screens/LoginPage.dart';
import '../model/genreServices.dart';
import '../model/movieServices.dart';
import '../screens/DetailPage.dart';
import '../custom/BorderIcon.dart';
import '../custom/OptionButton.dart';
import '../utils/constants.dart';
import '../utils/custom_functions.dart';
import '../utils/widget_functions.dart';
import '../widgets/nav-drawer.dart';

class SortedPage extends StatefulWidget {
  final List<dynamic> itemData;
  const SortedPage({Key? key, required this.itemData}) : super(key: key);

  @override
  // ignore: library_private_types_in_public_api
  _SortedPageState createState() => _SortedPageState();
}

class _SortedPageState extends State<SortedPage> {
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
                        itemCount: widget.itemData.length,
                        itemBuilder: (context, index) {
                          return MovieItem(
                            itemData: widget.itemData[index],
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
  const MovieItem({Key? key, required this.itemData}) : super(key: key);
  @override
  Widget build(BuildContext context) {
    final ThemeData themeData = Theme.of(context);
    Movie item = Movie(
        id: itemData['id'],
        title: itemData['title'],
        description: itemData['description'],
        moviePicture: itemData['moviePicture'],
        genres: itemData['genres'],
        reviews: itemData['reviews'],
        actors: itemData['actors']);
    String allGenres = "";
    for (var sub in item.genres) {
      // ignore: prefer_interpolation_to_compose_strings
      allGenres = allGenres + sub['genreName'] + " ";
    }

    var movieImage = itemData['moviePicture'].split(",");

    return GestureDetector(
      onTap: () {
        Navigator.of(context).push(MaterialPageRoute(
            builder: (context) => DetailPage(
                  itemData: item,
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
                  item.title,
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
              "$allGenres | ${item.title}",
              style: themeData.textTheme.headline5,
            )
          ],
        ),
      ),
    );
  }
}
