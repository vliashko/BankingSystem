import React, { useState } from 'react';
import axios from "axios";
import { Link, useNavigate } from "react-router-dom";
import './LoginPage.css';

/*axios.defaults.baseURL = "https://localhost:7222"*/

function LoginPage() {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const navigate = useNavigate(); 
   
    const handleSubmit = async(e) => {
        e.preventDefault();
        
        try 
        {
            const response = await axios.post("https://localhost:7222/auth/login", {username: username, password:password});
            console.log(response.data);
            const{accessToken, refreshToken, userId, roleId} = response.data;
            localStorage.setItem('access_token', accessToken);
            localStorage.setItem('refresh_token', refreshToken);
            localStorage.setItem('user_id', userId);
            localStorage.setItem('role_id', roleId);
            setUsername('');
            setPassword('');

            alert("Login successful!");
            const getRoleId = localStorage.getItem('role_id');

             if (getRoleId == 1) {
                navigate("/adminMainPage");
            }
             else 
             {
                navigate("/transactionPage");
             }
        }
        catch (error) {
            console.error("Login failed:", error);
            const errorMessage = error.response?.data?.message || error.message || "An error occurred during login.";

            alert("Login failed: " + errorMessage);
        }
       
    };

    return (
        <div className="login-container">
            <div className="login-wrapper">
                <h2 className="login-title">Welcome to Banking System</h2>
                <form className="login-form" onSubmit={handleSubmit}>
                    <div className="form-group">
                        <label htmlFor="username">Username</label>
                        <input
                            type="text"
                            id="username"
                            value={username}
                            onChange={e => setUsername(e.target.value)}
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="password">Password</label>
                        <input
                            type="password"
                            id="password"
                            value={password}
                            onChange={e => setPassword(e.target.value)}
                        />
                    </div>
                    <button type="submit" className="login-button">connexion</button>
                </form>
                <div>
                   <label>New account?<Link to = "/register">Register</Link></label>
                </div>
            </div>
        </div>
    );
}

export default LoginPage;
