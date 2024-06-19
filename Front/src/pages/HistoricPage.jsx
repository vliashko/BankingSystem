import React, { useState } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import logoutImage from './logout.png';
import './HistoricPage.css';

axios.defaults.baseURL = "https://localhost:7221";

function HistoricPage() {
    const [transactions, setTransactions] = useState([]);
    const [chunkSize, setChunkSize] = useState(1);
    const navigate = useNavigate();

    const fetchTransactions = async () => {
        const clientAccountId = localStorage.getItem('clientAccount_id');
        const access_token = localStorage.getItem('access_token');
        if (!clientAccountId || !access_token) {
            return;
        }

        try {
            const response = await axios.get(`banking/transactions/transaction/${clientAccountId}`, {
                headers: {
                    'Authorization': `Bearer ${access_token}`
                },
                params: {
                    chunkSize: chunkSize
                }
            });

            setTransactions(response.data);
        } 
        catch (error) {
            console.error('Failed to fetch transactions:', error);
        }
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        fetchTransactions();
    };

    const handleLogout = async (e) => {
        e.preventDefault();
        try {
            const refresh_token = localStorage.getItem('refresh_token');
            const access_token = localStorage.getItem('access_token');

            if (!refresh_token || !access_token) {
                throw new Error("No token found");
            }

            await axios.post("auth/logout", {}, {
                headers: {
                    'Authorization': `Bearer ${access_token}`,
                    'Refresh-Token': refresh_token
                }
            });

            localStorage.removeItem('access_token');
            localStorage.removeItem('refresh_token');
            localStorage.removeItem('user_id');
            localStorage.removeItem('clientAccount_id');
            localStorage.removeItem('role_id');


            alert("Logout successful!");
            navigate('/');
        } 
        catch (error) {
            console.error('Logout failed:', error);
        }
    };

    return (
        <div className="HistoricPage-container">
            <div className="logout" onClick={handleLogout}>
                <img src={logoutImage} alt="Logout" />
            </div>
            <div className="header">
                <h2>Transaction Historic</h2>
            </div>
            <div className="content">
                <form className="pagination-control" onSubmit={handleSubmit}>
                    <label htmlFor="chunkSize">per-page:</label>
                    <input
                        type="number"
                        id="chunkSize"
                        value={chunkSize}
                        onChange={e => setChunkSize(Number(e.target.value))}
                        min="1"
                    />
                    <button type="submit">Show</button>
                </form>
                <table className="transaction-table">
                    <thead>
                        <tr>
                            <th>Date</th>
                            <th>Amount</th>
                            <th>SenderNumberAccount</th>
                            <th>ConsumerNumberAccount</th>
                        </tr>
                    </thead>
                    <tbody>
                        {transactions.map(transaction => (
                            <tr key={transaction.id}>
                                <td>{new Date(transaction.dateOfTransaction).toLocaleString()}</td>
                                <td>{transaction.amount}</td>
                                <td>{transaction.senderNumberAccount}</td>
                                <td>{transaction.consumerNumberAccount}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </div>
    );
}

export default HistoricPage;
