import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import LoginPage from './components/LoginPage';
import RegisterPage from './components/RegisterPage';
import TransactionPage from './pages/TransactionPage';
import HistoricPage from './pages/HistoricPage';
import AdminMainPage from './pages/AdminMainPage';
import AdminHistoricPage from './pages/AdminHistoricPage';
import AdminPassportPage from './pages/AdminPassportPage';
import AddPassportPage from './pages/AddPassportPage';
import UpdatePassportPage from './pages/UpdatePassportPage';
import AdminBankPage from './pages/AdminBankPage';
import AddBankPage from './pages/AddBankPage';
import UpdateBankPage from './pages/UpdateBankPage';
import reportWebVitals from './reportWebVitals';

import {
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom";

const router = createBrowserRouter([
  {
    path: "/",
    element: <LoginPage />,
  },
  {
    path: "/register",
    element: <RegisterPage />,
  },
  {
    path: "/transactionPage",
    element: <TransactionPage />,
  },
  {
    path: "/historicPage",
    element: <HistoricPage />,
  },
  {
    path: "/adminMainPage",
    element: <AdminMainPage />,
  },
  {
    path: "/adminHistoricPage",
    element: <AdminHistoricPage />,
  },
  {
    path: "/adminPassportPage",
    element: <AdminPassportPage />,
  },
  {
    path: "/addPassportPage",
    element: <AddPassportPage />,
  },
  {
    path: "/updatePassportPage/:passportId",
    element: <UpdatePassportPage/>,
  },
  {
    path: "/adminBankPage",
    element: <AdminBankPage/>,
  },
  {
    path: "/addBankPage",
    element: <AddBankPage />,
  },
  {
    path: "/updateBankPage/:bankId",
    element: <UpdateBankPage/>,
  },

]);

ReactDOM.createRoot(document.getElementById("root")).render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
