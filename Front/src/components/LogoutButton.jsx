import React from "react";
import logoutImage from '../pages/logout.png';

function LogoutButton({ onClick }) {
    return (
        <div className="logout" onClick={onClick}>
            <img src={logoutImage} alt="Logout" />
        </div>
    );
}

export default LogoutButton;
