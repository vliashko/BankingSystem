import React, { useState } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import './AdminPassportPage.css';
import addIcon from './add.png';
import updateIcon from './update.png';
import deleteIcon from './delete.png';

axios.defaults.baseURL = "https://localhost:7221";

function AdminPassportPage() {
    const [passports, setPassports] = useState([]);
    const [pageSize, setPageSize] = useState(1)
    const [pageNumber, setPageNumber] = useState(1);
    const navigate = useNavigate();

    const fetchPassports = async () => {
        
            const access_token = localStorage.getItem('access_token');
            if (!access_token) {
                return;
            }

            try 
            {
            const response = await axios.get('banking/passports', {
                headers: {
                    'Authorization': `Bearer ${access_token}`
                },
                params: {
                    pageSize: pageSize,
                    pageNumber: pageNumber
                }
            });
            setPassports(response.data);
        } 
        catch (error) {
            console.error('Failed to fetch passports:', error);
        }
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        fetchPassports();
    };

    const handleAddPassport = () => {
        navigate('/addPassportPage');
    };

    const handleUpdatePassport = (passportId) => {
        navigate(`/updatePassportPage/${passportId}`);
    };

    const handleDeletePassport = async (passportId) => {
        try {
            const response = await axios.delete(`banking/passport/${passportId}`);
            console.log('Passport deleted:', response.data);

            alert("the passport has been deleted");
            fetchPassports();
        } catch (error) {
            console.error('Failed to delete passport:', error);
        }
    };

    return (
        <div className="AdminPassportPage-container">
            <div className="header">
                <h2>Passport Management</h2>
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
                    <button onClick={handleAddPassport}>
                        <img src={addIcon} alt="Add Passport" />
                    </button>
                </div>
                <table className="passport-table">
                    <thead>
                        <tr>
                            <th>Firstname</th>
                            <th>Surname</th>
                            <th>Date of Birthday</th>
                            <th>Date Issued</th>
                            <th>Date Expired</th>
                            <th>Nationality</th>
                            <th>PhoneNumber</th>
                            <th>Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        {passports.map(passport => (
                            <tr key={passport.id}>
                                <td>{passport.firstName}</td>
                                <td>{passport.surName}</td>
                                <td>{new Date(passport.dateOfBirth).toLocaleDateString()}</td>
                                <td>{new Date(passport.dateIssued).toLocaleDateString()}</td>
                                <td>{new Date(passport.dateExpired).toLocaleDateString()}</td>
                                <td>{passport.nationality}</td>
                                <td>{passport.phoneNumber}</td>
                                <td>
                                    <button onClick={() => handleUpdatePassport(passport.id)}>
                                        <img src={updateIcon} alt="Update" />
                                    </button>
                                    <button onClick={() => handleDeletePassport(passport.id)}>
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

export default AdminPassportPage;
