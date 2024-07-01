import React from "react";
import { useNavigate } from "react-router-dom";
import axios from 'axios';
import passportImage from './passport.png'; 
import statsImage from './stats.png'; 
import bankImage from './bank.png'; 
import logoutImage from './logout.png'; 
import './AdminMainPage.css';
import PanelItem from '../components/PanelItem';

function AdminMainPage() {
    const navigate = useNavigate();

    const handleHistoric = (e) =>{
        e.preventDefault();
        navigate('/adminHistoricPage');
    }
    const handlePassport = (e) =>{
        e.preventDefault();
        navigate('/adminPassportPage');
    }
    const handleBank = (e) =>{
        e.preventDefault();
        navigate('/adminBankPage');
    }

    const handleLogout = async (e) => {
        e.preventDefault();
        try {
            const refresh_token = localStorage.getItem('refresh_token');
            const access_token = localStorage.getItem('access_token');

            if (!refresh_token || !access_token) {
                throw new Error("No token found");
            }

            await axios.post("https://localhost:7222/auth/logout", {}, {
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
        } catch (error) {
            console.error('Logout failed:', error);
        }
    };

    return (
        <div>
            <div className="logout" onClick={handleLogout}>
                <img src={logoutImage} alt="Logout" />
            </div>
            <div className="header">
                <h1>Banking System</h1>
                <h2>Welcome to administrator mode</h2>
            </div>
            <div className="panel-container">
                <PanelItem 
                    label="Historic Handling"
                    imgSrc={statsImage}
                    altText="Historic Handling Icon"
                    className="historic-section"
                    onClick={handleHistoric}
                />
                <PanelItem 
                    label="Passport Handling"
                    imgSrc={passportImage}
                    altText="Passport Handling Icon"
                    className="passport-section"
                    onClick={handlePassport}
                />
                <PanelItem 
                    label="Bank Handling"
                    imgSrc={bankImage}
                    altText="Bank Handling Icon"
                    className="bank-section"
                    onClick={handleBank}
                />
            </div>
        </div>
    );
}

export default AdminMainPage;
