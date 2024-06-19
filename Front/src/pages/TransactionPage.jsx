import React, { useState, useEffect } from 'react';
import { useNavigate } from "react-router-dom";
import axios from 'axios';
import statsImage from './stats.png';
import logoutImage from './logout.png'; 
import './TransactionPage.css';
import InputField from '../components/InputField';

axios.defaults.baseURL = "https://localhost:7221";

function TransactionPage() {
    const [senderNumberAccount, setSenderNumberAccount] = useState('');
    const [consumerNumberAccount, setConsumerNumberAccount] = useState('');
    const [amount, setAmount] = useState('');
    const [balance, setBalance] = useState(0);
    const transactionTypeId = 1;
    const currency = 'usd';
    const token = 'tok_visa';
    const navigate = useNavigate();

    useEffect(() => {
        const fetchBalance = async () => {
            const clientAccountId = localStorage.getItem('clientAccount_id');
            const access_token = localStorage.getItem('access_token');
            if (!clientAccountId || !access_token) {
                return;
            }
    
            try {
                const response = await axios.get(`banking/client-accounts/client-account/${clientAccountId}`, {
                    headers: {
                        'Authorization': `Bearer ${access_token}`
                    }
                });

                setBalance(response.data.balance);
            } 
            catch (error) {
                console.error('Failed to fetch balance:', error);
            }
        };
    
        fetchBalance();
    }, []);

    const redirectToHistory = (e) => {
        e.preventDefault();
        navigate('/historicPage');
    };

    const handleTransactionSubmit = async (e) => {
        e.preventDefault();
        try {
            const clientAccountId = localStorage.getItem('clientAccount_id');
            const response = await axios.post("banking/transactions/transaction", {
                senderNumberAccount,
                consumerNumberAccount,
                amount,
                currency,
                token,
                transactionTypeId,
                ClientAccountId: clientAccountId
            });
            console.log('Transaction successful:', response.data);
            alert('The transaction has been done successfully');

            setSenderNumberAccount('');
            setConsumerNumberAccount('');
            setAmount('');
        } 
        catch (error) {
            console.error('Transaction failed:', error);
        }
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
        <div className="transactionPage-container">
            <div className="logout" onClick={handleLogout}>
                <img src={logoutImage} alt="Logout" />
            </div>
            <div className="header">
                <h2>Banking System</h2>
            </div>
            <div className="content">
                <div className="left-panel">
                    <div className="balance-section">
                        <label htmlFor="balance">Balance</label>
                        <input
                            id="balance"
                            type="text"
                            value={balance + "$"}
                            readOnly
                        />
                    </div>
                </div>
                <div className="right-panel">
                    <div className="history-section">
                        <label htmlFor="historic">Historics</label>
                        <img
                            src={statsImage}
                            className="history-icon"
                            onClick={redirectToHistory}
                            alt="Historic Icon"
                        />
                    </div>
                </div>
            </div>
            <div className="transaction-field">
                <form className="transaction-form" onSubmit={handleTransactionSubmit}>
                    <h3>Make Transaction</h3>
                    <div className="input-group">
                        <InputField 
                            id="senderNumberAccount"
                            label="Sender Number Account"
                            type="text"
                            value={senderNumberAccount}
                            onChange={(e) => setSenderNumberAccount(e.target.value)}
                        />
                        <InputField 
                            id="consumerNumberAccount"
                            label="Consumer Number Account"
                            type="text"
                            value={consumerNumberAccount}
                            onChange={(e) => setConsumerNumberAccount(e.target.value)}
                        />
                        <InputField 
                            id="amount"
                            label="Amount"
                            type="text"
                            value={amount}
                            onChange={(e) => setAmount(e.target.value)}
                        />
                    </div>
                    <button type="submit" className="sendButton">Send</button>
                </form>
            </div>
        </div>
    );
}

export default TransactionPage;
