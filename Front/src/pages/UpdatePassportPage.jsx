import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useNavigate, useParams } from 'react-router-dom';
import InputField from '../components/InputField';
import './UpdatePassportPage.css';

axios.defaults.baseURL = "https://localhost:7221";

function UpdatePassportPage() {
    const { passportId } = useParams();
    const [passportData, setPassportData] = useState({
        firstname: '',
        surName: '',
        dateOfBirth: '',
        dateisIssued: '',
        dateExpired: '',
        nationality: '',
        phoneNumber: ''
    });

    const navigate = useNavigate();

    useEffect(() => {
        const fetchPassport = async () => {
            try {
                const response = await axios.get(`banking/passportclient/${passportId}`);
                setPassportData(response.data);
            } catch (error) {
                console.error('Failed to fetch passport:', error);
            }
        };

        fetchPassport();
    }, [passportId]);

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
            const response = await axios.put(`banking/passport/${passportId}`, passportData, {
                headers: {
                    'Content-Type': 'application/json'
                }
            });
            console.log('Passport updated:', response.data);

            alert("The passport has been updated");
            navigate('/adminPassportPage');
        } catch (error) {
            console.error('Failed to update passport:', error);
        }
    };

    return (
        <div className="UpdatePassportPage-container">
            <div className="header">
                <h2>Update Passport</h2>
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
                    id="dateisIssued"
                    label="Date Issued"
                    type="date"
                    value={passportData.dateisIssued}
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
                <button type="submit">Update Passport</button>
            </form>
        </div>
    );
}

export default UpdatePassportPage;
