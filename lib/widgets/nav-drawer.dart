// ignore: file_names
import 'package:flutter/material.dart';
import 'package:movie_reviews_app/screens/LandingPage.dart';

import '../screens/FavoritePage.dart';
import '../screens/LoginPage.dart';

class NavDrawer extends StatelessWidget {
  const NavDrawer({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Drawer(
      child: ListView(
        padding: EdgeInsets.zero,
        children: <Widget>[
          const DrawerHeader(
            decoration: BoxDecoration(
                color: Colors.blueGrey,
                image: DecorationImage(
                    fit: BoxFit.fill,
                    image: AssetImage('assets/images/cover.jpg'))),
            child: Text(
              'Side menu',
              style: TextStyle(color: Colors.white, fontSize: 25),
            ),
          ),
          ListTile(
              leading: const Icon(Icons.movie),
              title: const Text('Home'),
              onTap: () {
                Navigator.push(
                  context,
                  MaterialPageRoute(builder: (context) => const LandingPage()),
                );
              }),
          if (isLoggedIn == true)
            ListTile(
                leading: const Icon(Icons.favorite),
                title: const Text('Favorite'),
                onTap: () {
                  Navigator.push(
                    context,
                    MaterialPageRoute(
                        builder: (context) => const FavoritePage()),
                  );
                }),
          if (isLoggedIn == false)
            ListTile(
              leading: const Icon(Icons.login),
              title: const Text('LogIn'),
              onTap: () {
                Navigator.push(
                  context,
                  MaterialPageRoute(
                      builder: (context) => const LoginPage(
                            title: 'LogIn Page',
                          )),
                );
              },
            ),
          if (isLoggedIn == true)
            ListTile(
              leading: const Icon(Icons.login),
              title: const Text('Log Out'),
              onTap: () {
                isLoggedIn = false;
                Navigator.push(
                  context,
                  MaterialPageRoute(builder: (context) => const LandingPage()),
                );
              },
            ),
        ],
      ),
    );
  }
}
