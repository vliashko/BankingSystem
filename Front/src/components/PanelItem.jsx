import React from "react";

function PanelItem({ label, imgSrc, altText, className , onClick }) {
    return (
        <div className={`panel ${className}`}>
            <label>{label}</label>
            <img src={imgSrc} alt={altText} onClick={onClick}/>
        </div>
    );
}

export default PanelItem;
