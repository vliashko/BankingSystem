import React, { useState } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import logoutImage from './logout.png';
import './AdminHistoricPage.css';

function AdminHistoricPage()
{
    const [transactions, setTransactions] = useState([]);
    const [pageSize, setPageSize] = useState(1)
    const [chunkSize, setChunkSize] = useState(1);
    const navigate = useNavigate();

    const fetchTransactions = async () => {
        const access_token = localStorage.getItem('access_token');
        if (!access_token) {
            return;
        }

        try {
            const response = await axios.get(`http://localhost:5215/api/banking/transactions`, {
                headers: {
                    'Authorization': `Bearer ${access_token}`
                },
                params: {
                    pageSize: pageSize,
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

            await axios.post("http://localhost:5215/api/auth/logout", {}, {
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
                <label htmlFor="pageSize">Page:</label>
                <input
                type="number"
                id="pageSize"
                value={pageSize}
                onChange={e => setPageSize(Number(e.target.value))}
                min="1"
                className="page-size-input"
            />
            <label htmlFor="chunkSize">Number:</label>
            <input
               type="number"
               id="chunkSize"
               value={chunkSize}
               onChange={e => setChunkSize(Number(e.target.value))}
               min="1"
               className="chunk-size-input"
            />
            <button type="submit">Show</button>
            </form>

                <table className="transaction-table">
                    <thead>
                        <tr>
                            <th>Date</th>
                            <th>Amount</th>
                            <th>SenderNumberAccount</th>
                            <th>SenderName</th>
                            <th>ConsumerNumberAccount</th>
                        </tr>
                    </thead>
                    <tbody>
                        {transactions.map(transaction => (
                            <tr key={transaction.id}>
                                <td>{new Date(transaction.dateOfTransaction).toLocaleString()}</td>
                                <td>{transaction.amount}</td>
                                <td>{transaction.senderNumberAccount}</td>
                                <td>{transaction.clientAccount?.user?.email || 'N/A'}</td>
                                <td>{transaction.consumerNumberAccount}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </div>
    );
}

export default AdminHistoricPage;