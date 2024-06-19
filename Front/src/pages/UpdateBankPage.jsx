import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useNavigate, useParams } from 'react-router-dom';
import InputField from '../components/InputField';
import './UpdateBankPage.css';

axios.defaults.baseURL = "https://localhost:7221";

function UpdateBankPage() {
    const { bankId } = useParams();
    const [bankData, setBankData] = useState({
        bankCode: '',
        name: '',
        city: '',
        phoneNumber: ''
    });

    const navigate = useNavigate();

    useEffect(() => {
        const fetchBanks = async () => {
            try {
                const response = await axios.get(`banking/banks/${bankId}`);
                setBankData(response.data);
            } catch (error) {
                console.error('Failed to fetch Banks:', error);
            }
        };

        fetchBanks();
    }, [bankId]);

    const handleChange = (e) => {
        const { name, value } = e.target;
        setBankData(prevState => ({
            ...prevState,
            [name]: value
        }));
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await axios.put(`banking/banks/${bankId}`, bankData, {
                headers: {
                    'Content-Type': 'application/json'
                }
            });
            console.log('Bank updated:', response.data);

            alert("The bank has been updated");
            navigate('/adminBankPage');
        } catch (error) {
            console.error('Failed to update bank:', error);
        }
    };

    return (
        <div className="UpdateBankPage-container">
            <div className="header">
                <h2>Update Bank</h2>
            </div>
            <form className="bank-form" onSubmit={handleSubmit}>
            <InputField
                    id="bankCode"
                    label="Bank Code"
                    type="number"
                    value={bankData.bankCode}
                    onChange={handleChange}
                    required
                />
                <InputField
                    id="name"
                    label="Name"
                    type="text"
                    value={bankData.name}
                    onChange={handleChange}
                    required
                />
                <InputField
                    id="city"
                    label="City"
                    type="text"
                    value={bankData.city}
                    onChange={handleChange}
                    required
                />
                <InputField
                    id="phoneNumber"
                    label="Phone Number"
                    type="text"
                    value={bankData.phoneNumber}
                    onChange={handleChange}
                    required
                />
                <button type="submit">Update Bank</button>
            </form>
        </div>
    );
}

export default UpdateBankPage;
