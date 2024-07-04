import React, { useState } from "react";
import axios from "axios";
import {Link, useNavigate} from "react-router-dom"
import './RegisterPage.css';

function RegisterPage()
{
    const[firstname, setFirstname] = useState('');
    const[lastname, setLastname] = useState('');
    const[email, setEmail] = useState('');
    const[username, setUsername] = useState('');
    const[password, setPassword] = useState('');
    const[confirmPassword, setConfirmpassword] = useState('');
    const [agreeToGetEmail, setAgreeToGetEmail] = useState('true');
    const navigate = useNavigate();

    const handleSubmit = async(e) => {
        e.preventDefault();
        
        if (password !== confirmPassword) {
            alert("Passwords do not match!");
            return;
        }

        try 
        {
            const response = await axios.post("http://localhost:5215/api/auth/register", {firstname:firstname, lastname:lastname, email:email, username: username, password:password, confirmPassword: confirmPassword, agreeToGetEmail: agreeToGetEmail ==='true'});
            console.log(response.data);
            const{accessToken, refreshToken} = response.data;
            localStorage.setItem('access_token', accessToken);
            localStorage.setItem('refresh_token', refreshToken);
       
            alert("The user has been added");
            navigate("/transactionPage"); 
        }
        catch (error) {
            console.error("Register failed:", error);
            const errorMessage = error.response?.data?.message || error.message || "An error occurred during register.";

            alert("Register failed: " + errorMessage);
        }
       
    };
    return (
        <div className="register-container">
            <div className="register-wrapper">
                <h2 className="register-title">Register</h2>
                <form className="register-form" onSubmit={handleSubmit}>
                    <div className="form-group">
                        <label htmlFor="firstname">Firstname</label>
                        <input
                            type="text"
                            id="firstname"
                            value={firstname}
                            onChange={e => setFirstname(e.target.value)}
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="lastname">Lastname</label>
                        <input
                            type="text"
                            id="lastname"
                            value={lastname}
                            onChange={e => setLastname(e.target.value)}
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="email">Email</label>
                        <input
                            type="text"
                            id="email"
                            value={email}
                            onChange={e => setEmail(e.target.value)}
                        />
                    </div>
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
                    <div className="form-group">
                        <label htmlFor="confirmpassword">ConfirmPassword</label>
                        <input
                            type="password"
                            id="confirmpassword"
                            value={confirmPassword}
                            onChange={e => setConfirmpassword(e.target.value)}
                        />
                    </div>
                    <div className="form-group">
                     <label htmlFor="agreeToGetEmail">Agree to get email?</label>
                     <select
                            id="agreeToGetEmail"
                            name="agreeToGetEmail"
                            value={agreeToGetEmail}
                            onChange={e => setAgreeToGetEmail(e.target.value)}
                        >
                            <option value="true">True</option>
                            <option value="false">False</option>
                        </select>
                    </div>
                    <button type="submit" className="register-button">Add user</button>
                </form>
                <div>
                    <label>Back to <Link to ="/">Login</Link></label>
                </div>
            </div>
        </div>
    );
}
export default RegisterPage;