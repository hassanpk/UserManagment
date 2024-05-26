import React from 'react';
import { useNavigate } from 'react-router-dom';
import { createUser } from '../Services/UserService';
import UserForm from '../Shared/UserForm';

const AddUser = () => {
  const navigate = useNavigate();

  const handleSubmit = async (userDetails) => {
    try {
      const formData = new FormData();
      Object.keys(userDetails).forEach(key => {
        formData.append(key, userDetails[key]);
      });
      await createUser(formData);
      navigate('/');
    } catch (error) {
      console.error('Failed to create user', error);
    }
  };

  return (
    <div className="container mt-4">
      <h3>Add User</h3>
      <UserForm onSubmit={handleSubmit} />
    </div>
  );
};

export default AddUser;
