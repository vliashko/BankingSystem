import React, { useState } from 'react';
import axios from 'axios';
import InputField from '../components/InputField';
import { useNavigate } from "react-router-dom";
import './AddBankPage.css';

function AddBankPage() {
    const [bankData, setBankData] = useState({
        bankCode: '',
        name: '',
        city: '',
        phoneNumber: ''
    });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setBankData(prevState => ({
            ...prevState,
            [name]: value
        }));
    };
    const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await axios.post('http://localhost:5215/api/banking/banks', bankData);
            console.log('Bank added:', response.data);

            alert("The bank has been added");
            navigate("/adminBankPage");
        } catch (error) {
            console.error('Failed to add bank:', error);
        }
    };

    return (
        <div className="AdminBankPage-container">
            <div className="header">
                <h2>Add Bank</h2>
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
                <button type="submit">Add Bank</button>
            </form>
        </div>
    );
}

export default AddBankPage;
