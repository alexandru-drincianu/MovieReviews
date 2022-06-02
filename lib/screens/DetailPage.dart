// ignore: file_names

import 'dart:convert';
import 'dart:io';

import 'package:comment_box/comment/comment.dart';
import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';
import 'package:flutter_rating_bar/flutter_rating_bar.dart';
import 'package:movie_reviews_app/model/reviewServices.dart';
import 'package:movie_reviews_app/model/userServices.dart';
import 'package:movie_reviews_app/screens/FavoritePage.dart';
import 'package:movie_reviews_app/screens/LandingPage.dart';
import 'package:movie_reviews_app/screens/LoginPage.dart';

import '../custom/BorderIcon.dart';
import '../custom/OptionButton.dart';
import '../model/movieServices.dart';
import '../utils/constants.dart';
import '../utils/custom_functions.dart';
import '../utils/widget_functions.dart';

Set<Map<String, String>> map = {};
bool added = false;

class DetailPage extends StatefulWidget {
  final dynamic itemData;

  const DetailPage({Key? key, @required this.itemData}) : super(key: key);
  @override
  _DetailPageState createState() => _DetailPageState();
}

class _DetailPageState extends State<DetailPage> {
  double _rating = 0;
  late Future<List<Review>> futureReview;
  late double userRating = 0;
  double ratingAvg = 0;
  Set<Map<String, dynamic>> usersRatings = {};
  // ignore: deprecated_member_use
  List<Review> _reviews = [];
  final formKey = GlobalKey<FormState>();
  final TextEditingController commentController = TextEditingController();
  late Future<List<Movie>> futureFavoriteMovie;
  late List<Movie> _favorite = [];
  late Future<Movie> futureCurrentMovie;
  dynamic currentMovie;

  @override
  void initState() {
    futureReview = fetchReviewsList();
    futureReview.then((reviews) {
      setState(() {
        for (var r in reviews) {
          if (r.movieId == widget.itemData.id) {
            _reviews.add(r);
            usersRatings.add({"userId": r.userId, "rating": r.rating});
            if (isLoggedIn == true) {
              if (r.userId == loggedInUser.id) {
                userRating = r.rating.toDouble();
              }
            }
          }
        }
      });
    });
    if (isLoggedIn == true) {
      futureFavoriteMovie = getUserFavorites(loggedInUser.id);
      futureFavoriteMovie.then((movies) {
        setState(() {
          _favorite = movies;
        });
      });
    }

    futureCurrentMovie = getMovieById(widget.itemData.id);
    futureCurrentMovie.then((movie) {
      setState(() {
        currentMovie = movie;
      });
    });

    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    final Size size = MediaQuery.of(context).size;
    final ThemeData themeData = Theme.of(context);
    const double padding = 25;
    const sidePadding = EdgeInsets.symmetric(horizontal: padding);
    final dynamic itemData;
    Future<Review>? _futureReview;

    var movieImage = widget.itemData.moviePicture.split(",");

    var reviewsMap = {
      for (var e in _reviews) {"name": e.userName, "message": e.description}
    };

    for (int i = 0; i < usersRatings.length; i++) {
      for (int j = i + 1; j < usersRatings.length; j++) {
        if (usersRatings.elementAt(j)['userId'] ==
            usersRatings.elementAt(i)['userId']) {
          usersRatings.remove(usersRatings.elementAt(i));
          i--;
          break;
        }
      }
    }

    ratingAvg = 0;
    int nrUsers = 0;
    if (usersRatings.isNotEmpty) {
      for (var a in usersRatings) {
        ratingAvg = ratingAvg + a['rating'];

        nrUsers++;
      }
      ratingAvg = ratingAvg / nrUsers;
      _rating = ratingAvg;
    }

    List<int> movieIds = [];
    for (var movie in _favorite) {
      movieIds.add(movie.id);
    }

    List<String> actorPictures = [];
    List<String> actorNames = [];
    for (var x in widget.itemData.actors) {
      actorPictures.add(x['image']);
      actorNames.add(x['name']);
    }

    return SafeArea(
      child: Scaffold(
        //backgroundColor: COLOR_WHITE,
        body: SizedBox(
          width: size.width,
          height: size.height,
          child: Stack(
            children: [
              SingleChildScrollView(
                physics: const BouncingScrollPhysics(),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Stack(
                      children: [
                        Image.memory(base64.decode(movieImage[1])),
                        Positioned(
                          width: size.width,
                          top: padding,
                          child: Padding(
                            padding: sidePadding,
                            child: Row(
                              mainAxisAlignment: MainAxisAlignment.spaceBetween,
                              children: [
                                InkWell(
                                  onTap: () {
                                    map.clear();
                                    added = false;
                                    Navigator.of(context).pop();
                                  },
                                  child: const BorderIcon(
                                    height: 50,
                                    width: 50,
                                    padding: EdgeInsets.zero,
                                    color: COLOR_WHITE,
                                    child: Icon(
                                      Icons.keyboard_backspace,
                                      color: COLOR_BLACK,
                                    ),
                                  ),
                                ),
                                IconButton(
                                  padding: const EdgeInsets.all(0),
                                  //alignment: Alignment.centerRight,
                                  icon: (FavoriteWidget(
                                      itemData: widget.itemData,
                                      movieIds: movieIds)),
                                  onPressed: _toggleFavorite,
                                ),
                              ],
                            ),
                          ),
                        ),
                      ],
                    ),
                    addVerticalSpace(padding),
                    Padding(
                      padding: sidePadding,
                      child: Row(
                        mainAxisAlignment: MainAxisAlignment.spaceBetween,
                        children: [
                          Column(
                            crossAxisAlignment: CrossAxisAlignment.start,
                            children: [
                              Text(
                                "${widget.itemData.title}",
                                style: themeData.textTheme.headline1,
                              ),
                              addVerticalSpace(5),
                              // Text(
                              //   "${widget.itemData.year}",
                              //   style: themeData.textTheme.subtitle2,
                              // ),
                            ],
                          ),
                        ],
                      ),
                    ),
                    addVerticalSpace(padding),
                    Padding(
                      padding: sidePadding,
                      child: Text(
                        "Actors",
                        style: themeData.textTheme.headline4,
                      ),
                    ),
                    addVerticalSpace(padding),
                    SizedBox(
                      height: 113,
                      child: ListView.builder(
                          physics: const BouncingScrollPhysics(),
                          scrollDirection: Axis.horizontal,
                          shrinkWrap: true,
                          itemCount: widget.itemData.actors.length,
                          itemBuilder: (context, index) {
                            return ActorItem(
                              itemData: widget.itemData.actors[index],
                              key: null,
                            );
                          }),
                    ),
                    addVerticalSpace(padding),
                    Padding(
                      padding: sidePadding,
                      child: Text(
                        "Description",
                        style: themeData.textTheme.headline4,
                      ),
                    ),
                    addVerticalSpace(padding),
                    Padding(
                      padding: sidePadding,
                      child: Text(
                        widget.itemData.description,
                        textAlign: TextAlign.justify,
                        style: themeData.textTheme.bodyText2,
                      ),
                    ),
                    addVerticalSpace(padding),
                    Padding(
                      padding: sidePadding,
                      child: Row(
                        mainAxisAlignment: MainAxisAlignment.spaceBetween,
                        children: [
                          Column(
                            crossAxisAlignment: CrossAxisAlignment.start,
                            children: [
                              Text(
                                "Rate: $ratingAvg",
                                style: themeData.textTheme.headline1,
                              ),
                              addVerticalSpace(5),
                            ],
                          ),
                          RatingBar.builder(
                            initialRating: userRating,
                            minRating: 1,
                            direction: Axis.horizontal,
                            allowHalfRating: false,
                            itemCount: 5,
                            itemPadding:
                                const EdgeInsets.symmetric(horizontal: 4.0),
                            itemBuilder: (context, _) => const Icon(
                              Icons.star,
                              color: Colors.amber,
                            ),
                            onRatingUpdate: (rating) {
                              if (isLoggedIn == false) {
                                ScaffoldMessenger.of(context).showSnackBar(
                                  const SnackBar(
                                    content: Text('You need to be logged in.'),
                                  ),
                                );
                              }
                              _updateRating(rating);
                            },
                          )
                        ],
                      ),
                    ),
                    SizedBox(
                      height: 300,
                      child: CommentBox(
                        userImage:
                            "https://www.kindpng.com/picc/m/24-248253_user-profile-default-image-png-clipart-png-download.png",
                        labelText: 'Write a comment...',
                        withBorder: false,
                        errorText: 'Comment cannot be blank',
                        sendButtonMethod: () {
                          if (isLoggedIn == false) {
                            ScaffoldMessenger.of(context).showSnackBar(
                              const SnackBar(
                                content: Text('You need to log in.'),
                              ),
                            );
                          }
                          if (formKey.currentState!.validate()) {
                            _futureReview = createReview(
                                loggedInUser.id,
                                widget.itemData.id,
                                _rating,
                                commentController.text);
                            setState(() {
                              map.add({
                                "name": loggedInUser.name,
                                "message": commentController.text
                              });
                            });
                            commentController.clear();
                            FocusScope.of(context).unfocus();
                          } else {
                            print("Not validated");
                          }
                        },
                        formKey: formKey,
                        commentController: commentController,
                        backgroundColor: Colors.black,
                        textColor: Colors.white,
                        sendWidget: const Icon(Icons.send_sharp,
                            size: 30, color: Colors.white),
                        child: commentChild(reviewsMap),
                      ),
                    ),
                  ],
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }

  void _updateRating(double rating) {
    setState(() {
      for (int i = 0; i < usersRatings.length; i++) {
        if (usersRatings.elementAt(i)['userId'] == loggedInUser.id) {
          usersRatings.elementAt(i)['rating'] = rating;
        }
      }

      double nrUsers = 0;
      ratingAvg = 0;
      for (var a in usersRatings) {
        ratingAvg = ratingAvg + a['rating'];
        nrUsers++;
      }

      ratingAvg = ratingAvg / nrUsers;
      _rating = rating;
    });
  }

  void _toggleFavorite() {
    setState(() {
      added = !added;
      print(added);
    });
  }

  Widget commentChild(data) {
    if (map.isNotEmpty) {
      for (var itm in map) {
        data.add(itm);
      }
    }
    //map.clear();
    return ListView(
      children: [
        for (var i = data.length - 1; i >= 0; i--)
          Padding(
            padding: const EdgeInsets.fromLTRB(2.0, 8.0, 2.0, 0.0),
            child: ListTile(
              leading: GestureDetector(
                onTap: () async {
                  // Display the image in large form.
                  print("Comment Clicked");
                },
                child: Container(
                  height: 50.0,
                  width: 50.0,
                  decoration: const BoxDecoration(
                      color: Colors.blue,
                      borderRadius: BorderRadius.all(Radius.circular(50))),
                  child: const CircleAvatar(
                      radius: 50,
                      backgroundImage: NetworkImage(
                          "https://www.kindpng.com/picc/m/24-248253_user-profile-default-image-png-clipart-png-download.png")),
                ),
              ),
              title: Text(
                data.elementAt(i)['name'],
                style: const TextStyle(fontWeight: FontWeight.bold),
              ),
              subtitle: Text(data.elementAt(i)['message']),
            ),
          )
      ],
    );
  }
}

class InformationTile extends StatelessWidget {
  final dynamic content;
  final String name;

  const InformationTile({Key? key, required this.content, required this.name})
      : super(key: key);

  @override
  Widget build(BuildContext context) {
    final ThemeData themeData = Theme.of(context);
    final Size size = MediaQuery.of(context).size;
    final double tileSize = size.width * 0.20;
    return Container(
      margin: const EdgeInsets.only(left: 25),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.center,
        children: [
          BorderIcon(
              width: tileSize,
              height: tileSize,
              padding: EdgeInsets.zero,
              color: COLOR_BLACK,
              child: Image.memory(content)),
          addVerticalSpace(15),
          Text(
            name,
            style: themeData.textTheme.headline6,
          )
        ],
      ),
    );
  }
}

// ignore: must_be_immutable
class FavoriteWidget extends StatefulWidget {
  late dynamic itemData;
  late dynamic movieIds;

  FavoriteWidget({super.key, this.itemData, this.movieIds});

  @override
  // ignore: library_private_types_in_public_api
  _FavoriteWidgetState createState() => _FavoriteWidgetState();
}

class _FavoriteWidgetState extends State<FavoriteWidget> {
  void _toggleFavorite() {
    setState(() {
      added = !added;
    });
  }

  @override
  Widget build(BuildContext context) {
    if (widget.movieIds.contains(widget.itemData.id) || added == true) {
      return InkWell(
        onTap: () {
          if (isLoggedIn == false) {
            ScaffoldMessenger.of(context).showSnackBar(
              const SnackBar(
                content: Text('You need to be logged in.'),
              ),
            );
          } else {
            if (widget.movieIds.contains(widget.itemData.id)) {
              added = true;
              widget.movieIds.remove(widget.itemData.id);
            }
            _toggleFavorite();
            removeFromFavorite(loggedInUser.id, widget.itemData.id);
            ScaffoldMessenger.of(context).showSnackBar(
              const SnackBar(
                content: Text('Removed from favorites.'),
              ),
            );
          }
        },
        child: const BorderIcon(
          height: 50,
          width: 50,
          padding: EdgeInsets.zero,
          color: Colors.red,
          child: Icon(
            Icons.favorite_border,
            color: COLOR_BLACK,
          ),
        ),
      );
    } else {
      return InkWell(
        onTap: () {
          if (isLoggedIn == false) {
            ScaffoldMessenger.of(context).showSnackBar(
              const SnackBar(
                content: Text('You need to be logged in.'),
              ),
            );
          } else {
            _toggleFavorite();
            addToFavorite(loggedInUser.id, widget.itemData.id);
            ScaffoldMessenger.of(context).showSnackBar(
              const SnackBar(
                content: Text('Added to favorites.'),
              ),
            );
          }
        },
        child: const BorderIcon(
          height: 50,
          width: 50,
          padding: EdgeInsets.zero,
          color: COLOR_WHITE,
          child: Icon(
            Icons.favorite_border,
            color: COLOR_BLACK,
          ),
        ),
      );
    }
  }
}

class ActorItem extends StatelessWidget {
  final dynamic itemData;

  const ActorItem({Key? key, this.itemData}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    var actorImage = itemData['image'].split(",");
    return GestureDetector(
      onTap: () {},
      child: SingleChildScrollView(
        scrollDirection: Axis.horizontal,
        physics: const BouncingScrollPhysics(),
        child: Row(
          children: [itemData]
              .map((filter) => InformationTile(
                  content: base64.decode(actorImage[1]),
                  name: itemData['name']))
              .toList(),
        ),
      ),
    );
  }
}
