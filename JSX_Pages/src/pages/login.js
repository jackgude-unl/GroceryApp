import React from 'react';
import '../App.css';

function LoginPage() {
    return (
        <div className="login">
            <h1>Login</h1>
            <form className="login-form">
                <label>
                    Username:
                    <input type="text" name="username" required />
                </label>
                <label>
                    Password:
                    <input type="password" name="password" required />
                </label>
                <button type="submit">Login</button>
            </form>
        </div>
    );
}

export default LoginPage;