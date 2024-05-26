import React from 'react';
import { Link } from 'react-router-dom';
import { deleteUser } from '../Services/UserService';

const UserItem = ({ user, onDelete }) => {
  const handleDelete = async () => {
    if (window.confirm('Are you sure you want to delete this user?')) {
      await deleteUser(user.id);
      onDelete(user.id);
    }
  };

  return (
    <tr>
      <td>{user.name}</td>
      <td>{user.employeeType}</td>
      <td>{user.mobileNo}</td>
      <td>{user.email}</td>
      <td>{user.nationality}</td>
      <td>{user.designation}</td>
      <td>
      <Link to={`/view/${user.id}`} className="me-2 text-decoration-none">
         View
      </Link>
      <Link to={`/edit/${user.id}`} className="me-2 text-decoration-none">
        Edit
      </Link>
      <button onClick={() => handleDelete(user.id)} className="btn btn-link text-danger">
       Delete
      </button>
      </td>
    </tr>
  );
};

export default UserItem;
