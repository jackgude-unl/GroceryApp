import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import '../App.css';
import '../css-pages/login.css';

function LoginPage({ onLogin }) {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await fetch("http://localhost:5156/api/Users/login", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({ email, password }),
            });

            if (response.ok) {
                const data = await response.json();
                onLogin(data);
                navigate("/");
            } else {
                alert("Login failed. Please check your credentials.");
            }
        } catch (error) {
            console.error("Error logging in:", error);
        }
    };

    const handleNavigateToCreateUser = () => {
        navigate("/create-user");
    };

    return (
        <div className="login">
            <h1>Login</h1>
            <form className="login-form" onSubmit={handleSubmit}>
                <label>
                    Email:
                    <input
                        type="email"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        required
                    />
                </label>
                <label>
                    Password:
                    <input
                        type="password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        required
                    />
                </label>
                <div className="button-group">
                    <button type="submit" className="form-button">
                        Login
                    </button>
                    <button
                        type="button"
                        onClick={handleNavigateToCreateUser}
                        className="form-button"
                    >
                        Register
                    </button>
                </div>
            </form>
        </div>
    );
}

export default LoginPage;


