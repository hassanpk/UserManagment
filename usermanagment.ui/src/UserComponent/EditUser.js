import React, { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { getUser, updateUser } from '../Services/UserService';
import UserForm from '../Shared/UserForm';

const EditUser = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const [userDetails, setUserDetails] = useState(null);

  useEffect(() => {
    const fetchUser = async () => {
      try {
        const response = await getUser(id);
        setUserDetails(response.data);
      } catch (error) {
        console.error('Failed to fetch user', error);
      }
    };
    fetchUser();
  }, [id]);

  const handleSubmit = async (userDetails) => {
    try {
      const formData = new FormData();
      Object.keys(userDetails).forEach(key => {
        formData.append(key, userDetails[key]);
      });
      await updateUser(id, formData);
      navigate('/');
    } catch (error) {
      console.error('Failed to update user', error);
    }
  };

  if (!userDetails) {
    return <div>Loading...</div>;
  }

  return (
    <div className="container mt-4">
      <h3>Edit User</h3>
      <UserForm initialData={userDetails} onSubmit={handleSubmit} />
    </div>
  );
};

export default EditUser;
