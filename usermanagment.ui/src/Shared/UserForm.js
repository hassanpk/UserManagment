import React, { useState } from 'react';

const UserForm = ({ initialData = {}, onSubmit }) => {
  const [userDetails, setUserDetails] = useState({
    locationId: initialData.locationId || '',
    employeeType: initialData.employeeType || '',
    name: initialData.name || '',
    mobileNo: initialData.mobileNo || '',
    email: initialData.email || '',
    nationality: initialData.nationality || '',
    designation: initialData.designation || '',
    passportNo: initialData.passportNo || '',
    passportExpiryDate: initialData.passportExpiryDate || '',
    passportFilePath: null,
    personPhoto: null,
    passportFilePreview: null,
    personPhotoPreview: null
  });

  function formatDate(dateString) {
    const date = new Date(dateString);
    const day = date.getDate().toString().padStart(2, '0'); // Get day and pad with leading zero if needed
    const month = (date.getMonth() + 1).toString().padStart(2, '0'); // Get month (zero-based index) and pad with leading zero if needed
    const year = date.getFullYear();
    return `${day}/${month}/${year}`; // Format as dd/mm/yyyy
  }

  const [errors, setErrors] = useState({});

  const handleChange = (e) => {
    const { name, value } = e.target;
    setUserDetails({ ...userDetails, [name]: value });
  };

  const handleFileChange = (e) => {
    const { name, files } = e.target;
    const file = files[0];
    const reader = new FileReader();

    reader.onloadend = () => {
      setUserDetails({
        ...userDetails,
        [name]: file,
        [`${name}Preview`]: reader.result
      });
    };

    if (file) {
      reader.readAsDataURL(file);
    }
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    if (validateForm()) {
      onSubmit(userDetails);
      // Clear file inputs after submitting
      setUserDetails({
        ...userDetails,
        passportFile: null,
        personPhoto: null,
        passportFilePreview: null,
        personPhotoPreview: null
      });
    }
  };

  const validateForm = () => {
    const errors = {};
    let isValid = true;

    if (!userDetails.name.trim()) {
      errors.name = 'Name is required';
      isValid = false;
    }

    if (!userDetails.locationId.trim()) {
      errors.locationId = 'Location ID is required';
      isValid = false;
    }

    if (!userDetails.employeeType.trim()) {
      errors.employeeType = 'Employee Type is required';
      isValid = false;
    }

    if (!userDetails.mobileNo.trim()) {
      errors.mobileNo = 'Mobile No is required';
      isValid = false;
    }

    if (!userDetails.email.trim()) {
      errors.email = 'Email is required';
      isValid = false;
    } else if (!/\S+@\S+\.\S+/.test(userDetails.email)) {
      errors.email = 'Email is invalid';
      isValid = false;
    }

    if (!userDetails.passportNo.trim()) {
      errors.passportNo = 'Passport No is required';
      isValid = false;
    }

    if (!userDetails.designation.trim()) {
      errors.designation = 'Designation is required';
      isValid = false;
    }

    if (!userDetails.nationality.trim()) {
      errors.nationality = 'Nationality is required';
      isValid = false;
    }

    if (!userDetails.passportExpiryDate.trim()) {
      errors.passportExpiryDate = 'Passport Expiry Date is required';
      isValid = false;
    }

    if (!userDetails.passportFile) {
      errors.passportFile = 'Passport File is required';
      isValid = false;
    }
    if (!userDetails.personPhoto) {
      errors.personPhoto = 'UserPhoto File is required';
      isValid = false;
    }

    setErrors(errors);
    return isValid;
  };

  return (
    <form onSubmit={handleSubmit}>
      <div className="row mb-3">
        <label className="col-sm-2 col-form-label">Name:</label>
        <div className="col-sm-4">
          <input type="text" name="name" value={userDetails.name} onChange={handleChange} className="form-control" />
          {errors.name && <div className="text-danger">{errors.name}</div>}
        </div>
        <label className="col-sm-2 col-form-label">Location Id:</label>
        <div className="col-sm-4">
          <input type="text" name="locationId" value={userDetails.locationId} onChange={handleChange} className="form-control" />
          {errors.locationId && <div className="text-danger">{errors.locationId}</div>}
        </div>
      </div>

      <div className="row mb-3">
        <label className="col-sm-2 col-form-label">Employee Type:</label>
        <div className="col-sm-4">
          <input type="text" name="employeeType" value={userDetails.employeeType} onChange={handleChange} className="form-control" />
          {errors.employeeType && <div className="text-danger">{errors.employeeType}</div>}
        </div>
        <label className="col-sm-2 col-form-label">Mobile:</label>
        <div className="col-sm-4">
          <input type="text" name="mobileNo" value={userDetails.mobileNo} onChange={handleChange} className="form-control" />
          {errors.mobileNo && <div className="text-danger">{errors.mobileNo}</div>}
        </div>
      </div>

      <div className="row mb-3">
        <label className="col-sm-2 col-form-label">Email:</label>
        <div className="col-sm-4">
          <input type="text" name="email" value={userDetails.email} onChange={handleChange} className="form-control" />
          {errors.email && <div className="text-danger">{errors.email}</div>}
        </div>
        <label className="col-sm-2 col-form-label">Passport No:</label>
        <div className="col-sm-4">
          <input type="text" name="passportNo" value={userDetails.passportNo} onChange={handleChange} className="form-control" />
          {errors.passportNo && <div className="text-danger">{errors.passportNo}</div>}
        </div>
      </div>

      <div className="row mb-3">
        <label className="col-sm-2 col-form-label">Designation:</label>
        <div className="col-sm-4">
          <input type="text" name="designation" value={userDetails.designation} onChange={handleChange} className="form-control" />
          {errors.designation && <div className="text-danger">{errors.designation}</div>}
        </div>
        <label className="col-sm-2 col-form-label">Nationality:</label>
        <div className="col-sm-4">
          <input type="text" name="nationality" value={userDetails.nationality} onChange={handleChange} className="form-control" />
          {errors.nationality && <div className="text-danger">{errors.nationality}</div>}
        </div>
      </div>

      <div className="row mb-3">
        <label className="col-sm-2 col-form-label">Passport Expiry Date:</label>
        <div className="col-sm-4">
          <input type="date" name="passportExpiryDate" value={userDetails.passportExpiryDate.split("T")[0]} onChange={handleChange} className="form-control" />
          {errors.passportExpiryDate && <div className="text-danger">{errors.passportExpiryDate}</div>}
        </div>
      </div>

      <div className="row mb-3">
        <label className="col-sm-2 col-form-label">Passport File:</label>
        <div className="col-sm-4">
          <input type="file" name="passportFile" onChange={handleFileChange} className="form-control" />
          {errors.passportFile && <div className="text-danger">{errors.passportFile}</div>}
        </div>
        {userDetails.passportFilePreview && (
          <div className="col-sm-6">
            <img src={userDetails.passportFilePreview} alt="Passport File Preview" className="img-thumbnail" />
          </div>
        )}
      </div>
      
      <div className="row mb-3">
        <label className="col-sm-2 col-form-label">Person Photo:</label>
        <div className="col-sm-4">
          <input type="file" name="personPhoto" onChange={handleFileChange} className="form-control" />
          {errors.personPhoto && <div className="text-danger">{errors.personPhoto}</div>}
        </div>
        {userDetails.personPhotoPreview && (
          <div className="col-sm-6">
            <img src={userDetails.personPhotoPreview} alt="Person Photo Preview" className="img-thumbnail" />
          </div>
        )}
      </div>
  
      <div className="row mb-3">
        <div className="col-sm-10 offset-sm-2">
          <button type="submit" className="btn btn-primary">Submit</button>
        </div>
      </div>
    </form>
  );
};

export default UserForm;
