import React from 'react';

function InputField({ id, label, type, value, onChange, required }) {
    return (
        <div className="input-field">
            <label htmlFor={id}>{label}</label>
            <input
                id={id}
                name={id}
                type={type}
                value={value}
                onChange={onChange}
                required={required}
            />
        </div>
    );
}

export default InputField;
