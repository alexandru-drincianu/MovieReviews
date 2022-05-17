// import 'dart:async';
// import 'dart:convert';

// import 'package:flutter/material.dart';
// import 'package:http/http.dart' as http;

// import 'model/fetchUser.dart';

// class UserTest extends StatefulWidget {
//   const UserTest({Key? key}) : super(key: key);

//   @override
//   _UserTestState createState() => _UserTestState();
// }

// class _UserTestState extends State<UserTest> {
//   late Future<User> futureUser;

//   @override
//   void initState() {
//     super.initState();
//     futureUser = fetchUser();
//   }

//   @override
//   Widget build(BuildContext context) {
//     return MaterialApp(
//       title: 'Fetch Data Example',
//       theme: ThemeData(
//         primarySwatch: Colors.blue,
//       ),
//       home: Scaffold(
//         appBar: AppBar(
//           title: const Text('Fetch Data Example'),
//         ),
//         body: Center(
//           child: FutureBuilder<User>(
//             future: futureUser,
//             builder: (context, snapshot) {
//               if (snapshot.hasData) {
//                 return Text(snapshot.data!.name);
//               } else if (snapshot.hasError) {
//                 return Text('${snapshot.error}');
//               }

//               // By default, show a loading spinner.
//               return const CircularProgressIndicator();
//             },
//           ),
//         ),
//       ),
//     );
//   }
// }
