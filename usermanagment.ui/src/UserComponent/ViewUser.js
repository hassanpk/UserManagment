import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { getUser } from '../Services/UserService';
const { REACT_APP_BASE_URL } = process.env;


const ViewUser = () => {

    const { id } = useParams();
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

    if (!userDetails) {
        return <div>Loading...</div>;
    }
    return (
        <div className="container mt-4">
            <div className="row">
                <div className="col-md-4">
                    <div className="card border-0">
                        <div className="card-body text-center">
                            <img src={ REACT_APP_BASE_URL + userDetails.photoFilePath} alt="Profile" className="img-fluid" style={{ width: '150px' }} />
                        </div>
                    </div>
                </div>

                <div className="col-md-8">
                    <div className="card border-0">
                        <div className="card-body">
                            <h4 className="card-title">User Information</h4>
                            <ul className="list-group list-group-flush">
                            <li className="list-group-item"><strong>Name:</strong> {userDetails.name}</li>
                                <li className="list-group-item"><strong>Email:</strong> {userDetails.email}</li>
                                <li className="list-group-item"><strong>Location ID:</strong> {userDetails.locationId}</li>
                                <li className="list-group-item"><strong>Nationality:</strong> {userDetails.nationality}</li>
                                <li className="list-group-item"><strong>Designation:</strong> {userDetails.designation}</li>
                                <li className="list-group-item"><strong>MobileNo:</strong> {userDetails.mobileNo}</li>
                                <li className="list-group-item"><strong>Passport No:</strong> {userDetails.passportNo}</li>
                                <li className="list-group-item"><strong>Passport Expiry Date:</strong> {userDetails.passportExpiryDate}</li>
                            </ul>
                            <div className='mt-4'>
                                <h4>Passport Image</h4>
                            <img src={ REACT_APP_BASE_URL + userDetails.passportFilePath} alt="PassPort Photo" className="img-fluid" style={{ width: '150px' }} />
                            </div>
                        </div>
                    </div>
                </div>
                        </div>
        </div>
    );
}

export default ViewUser;
