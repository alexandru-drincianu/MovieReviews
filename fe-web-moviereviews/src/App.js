
import './App.css';
import React from 'react';
import LandingPage from './components/LandingPage/LandingPage';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import SignIn from './components/SignIn/SignIn';
import SignUp from './components/SignUp/SignUp';
import AddMovie from './components/AddMovie/AddMovie';
import BrowseMovie from './components/BrowseMovie';
import MoviePage from './components/MoviePage/MoviePage';
import AddActor from './components/AddActor/AddActor';

const App = () => {
  return (
    <BrowserRouter>
      <Routes>
        <Route exact path="/" element={<LandingPage />}></Route>
        <Route exact path="/signin" element={<SignIn />}></Route>
        <Route exact path="/signup" element={<SignUp />}></Route>
        <Route exact path="/addmovie" element={<AddMovie />}></Route>
        <Route exact path="/movies" element={<BrowseMovie />}></Route>
        <Route exact path="/movies/:id" element={<MoviePage />}></Route>
        <Route exact path='/addactor' element={<AddActor />} />
      </Routes>
    </BrowserRouter>
  );
}


export default App;
