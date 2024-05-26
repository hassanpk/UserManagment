import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { getUsers } from '../Services/UserService';
import UserItem from '../Shared/UserItem';

const ListUser = () => {
  const [users, setUsers] = useState([]);

  useEffect(() => {
    const fetchUsers = async () => {
      const response = await getUsers();
      setUsers(response.data);
    };
    fetchUsers();
  }, []);

  const handleDelete = (id) => {
    setUsers(users.filter(user => user.id !== id));
  };

  return (
    <div className="container mt-4">
      <h2>All Users</h2>
      <Link to="/add" className="btn btn-primary mb-3">Add User</Link>
      <table className="table table-bordered table-responsive">
        <thead>
          <tr>
            <th>Name</th>
            <th>EmployeeType</th>
            <th>MobileNo</th>
            <th>Email</th>
            <th>Nationality</th>
            <th>Designation</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {users.map(user => (
            <UserItem key={user.id} user={user} onDelete={handleDelete} />
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default ListUser;
