import React, { useState } from 'react';
import axios from 'axios';
import InputField from '../components/InputField';
import './AddPassportPage.css';


function AddPassportPage() {
    const [passportData, setPassportData] = useState({
        firstname: '',
        surName: '',
        dateOfBirth: '',
        dateIssued: '',
        dateExpired: '',
        nationality: '',
        phoneNumber: ''
    });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setPassportData(prevState => ({
            ...prevState,
            [name]: value
        }));
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await axios.post('http://localhost:5215/api/banking/passport', passportData);
            console.log('Passport added:', response.data);

            alert("The passport has been added");
        } catch (error) {
            console.error('Failed to add passport:', error);
        }
    };

    return (
        <div className="AdminPassportPage-container">
            <div className="header">
                <h2>Add Passport</h2>
            </div>
            <form className="passport-form" onSubmit={handleSubmit}>
                <InputField
                    id="firstname"
                    label="Firstname"
                    type="text"
                    value={passportData.firstname}
                    onChange={handleChange}
                    required
                />
                <InputField
                    id="surName"
                    label="Surname"
                    type="text"
                    value={passportData.surName}
                    onChange={handleChange}
                    required
                />
                <InputField
                    id="dateOfBirth"
                    label="Date of Birth"
                    type="date"
                    value={passportData.dateOfBirth}
                    onChange={handleChange}
                    required
                />
                <InputField
                    id="dateIssued"
                    label="Date Issued"
                    type="date"
                    value={passportData.dateIssued}
                    onChange={handleChange}
                    required
                />
                <InputField
                    id="dateExpired"
                    label="Date Expired"
                    type="date"
                    value={passportData.dateExpired}
                    onChange={handleChange}
                    required
                />
                <InputField
                    id="nationality"
                    label="Nationality"
                    type="text"
                    value={passportData.nationality}
                    onChange={handleChange}
                    required
                />
                <InputField
                    id="phoneNumber"
                    label="Phone Number"
                    type="text"
                    value={passportData.phoneNumber}
                    onChange={handleChange}
                />
                <button type="submit">Add Passport</button>
            </form>
        </div>
    );
}

export default AddPassportPage;
