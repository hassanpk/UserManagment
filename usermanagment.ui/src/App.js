import React from 'react';
import { BrowserRouter as Router, Route, Routes, Link } from 'react-router-dom';
import ListUser from './UserComponent/ListUser';
import AddUser from './UserComponent/AddUser';
import EditUser from './UserComponent/EditUser';
import ViewUser from './UserComponent/ViewUser';
import Navbar from './Shared/Navbar';


const App = () => (
  <Router>
    <div className="container">
      <Navbar/>
      <Routes>
        <Route path="/" element={<ListUser />} />
        <Route path="/add" element={<AddUser />} />
        <Route path="/edit/:id" element={<EditUser />} />
        <Route path="/view/:id" element={<ViewUser />} />
      </Routes>
    </div>
  </Router>
);

export default App;
