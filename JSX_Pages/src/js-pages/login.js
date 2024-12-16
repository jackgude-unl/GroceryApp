import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import '../App.css';
import '../css-pages/login.css';

function LoginPage({ onLogin }) {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);
    const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();
        setLoading(true);
        setError(null);

        try {
            const response = await fetch("http://localhost:5156/api/Users/login", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({ email, password }),
            });

            const data = await response.json();

            if (response.ok) {
                localStorage.setItem('userId', data.userId);
                localStorage.setItem('userEmail', data.email);
                
                console.log('User logged in:', {
                    userId: localStorage.getItem('userId'),
                    userEmail: localStorage.getItem('userEmail')
                });

                onLogin(data);
                
                navigate("/");
            } else {
                setError(data.error || "Login failed. Please check your credentials.");
                console.error("Login failed:", data);
            }
        } catch (error) {
            setError("Error connecting to the server. Please try again.");
            console.error("Error logging in:", error);
        } finally {
            setLoading(false);
        }
    };

    const handleNavigateToCreateUser = () => {
        navigate("/create-user");
    };

    return (
        <div className="login">
            <h1>Login</h1>
            {error && <p className="error-message">{error}</p>}
            <form className="login-form" onSubmit={handleSubmit}>
                <label>
                    Email:
                    <input
                        type="email"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        required
                        disabled={loading}
                    />
                </label>
                <label>
                    Password:
                    <input
                        type="password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        required
                        disabled={loading}
                    />
                </label>
                <div className="button-group">
                    <button 
                        type="submit" 
                        className="form-button"
                        disabled={loading}
                    >
                        {loading ? "Logging in..." : "Login"}
                    </button>
                    <button
                        type="button"
                        onClick={handleNavigateToCreateUser}
                        className="form-button"
                        disabled={loading}
                    >
                        Register
                    </button>
                </div>
            </form>
        </div>
    );
}

export default LoginPage;


