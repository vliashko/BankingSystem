import React, { useState } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import './AdminBankPage.css';
import addIcon from './add.png';
import updateIcon from './update.png';
import deleteIcon from './delete.png';

function AdminBankPage() {
    const [banks, setBanks] = useState([]);
    const [pageSize, setPageSize] = useState(1)
    const [pageNumber, setPageNumber] = useState(1);
    const navigate = useNavigate();

    const fetchBanks = async () => {
        
            const access_token = localStorage.getItem('access_token');
            if (!access_token) {
                return;
            }

            try 
            {
            const response = await axios.get('https://localhost:7221/banking/banks', {
                headers: {
                    'Authorization': `Bearer ${access_token}`
                },
                params: {
                    pageSize: pageSize,
                    pageNumber: pageNumber
                }
            });
            setBanks(response.data);
        } 
        catch (error) {
            console.error('Failed to fetch passports:', error);
        }
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        fetchBanks();
    };

    const handleAddBank = () => {
        navigate('/addBankPage');
    };

    const handleUpdateBank = (bankId) => {
        navigate(`/updateBankPage/${bankId}`);
    };

    const handleDeleteBank = async (bankId) => {
        try {
            const response = await axios.delete(`banking/banks/${bankId}`);
            console.log('Bank deleted:', response.data);

            alert("the bank has been deleted");
            fetchBanks();
        } catch (error) {
            console.error('Failed to delete bank:', error);
        }
    };

    return (
        <div className="AdminBankPage-container">
            <div className="header">
                <h2>Bank Management</h2>
            </div>
            <form className="pagination-control" onSubmit={handleSubmit}>
                <label htmlFor="pageSize">Number:</label>
                <input
                    type="number"
                    id="pageSize"
                    value={pageSize}
                    onChange={e => setPageSize(Number(e.target.value))}
                    min="1"
                    className="page-size-input"
                />
                <label htmlFor="pageNumber">Page:</label>
                <input
                    type="number"
                    id="pageSize"
                    value={pageNumber}
                    onChange={e => setPageNumber(Number(e.target.value))}
                    min="1"
                    className="chunk-size-input"
                />
                <button type="submit">Show</button>
            </form>
            <div className="content">
                <div className="action-buttons">
                    <button onClick={handleAddBank}>
                        <img src={addIcon} alt="Add Bank" />
                    </button>
                </div>
                <table className="bank-table">
                    <thead>
                        <tr>
                            <th>BankCode</th>
                            <th>Name</th>
                            <th>City</th>
                            <th>Phone Number</th>
                            <th>Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        {banks.map(bank => (
                            <tr key={bank.id}>
                                <td>{bank.bankCode}</td>
                                <td>{bank.name}</td>
                                <td>{bank.city}</td>
                                <td>{bank.phoneNumber}</td>
                                <td>
                                    <button onClick={() => handleUpdateBank(bank.id)}>
                                        <img src={updateIcon} alt="Update" />
                                    </button>
                                    <button onClick={() => handleDeleteBank(bank.id)}>
                                        <img src={deleteIcon} alt="Delete" />
                                    </button>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </div>
    );
}

export default AdminBankPage;
