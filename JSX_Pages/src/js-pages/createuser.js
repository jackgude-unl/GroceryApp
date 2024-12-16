import React, { useState } from "react";
import "../css-pages/createuser.css";

function CreateUserPage() {
    const [firstName, setFirstName] = useState("");
    const [lastName, setLastName] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    const handleCreateUser = async () => {
        try {
            const response = await fetch("http://localhost:5156/api/Users/create", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({ firstName, lastName, email, password }),
            });

            if (response.ok) {
                alert("User created successfully!");
                setFirstName("");
                setLastName("");
                setEmail("");
                setPassword("");
            } else {
                alert("Failed to create user. Please check the details.");
            }
        } catch (error) {
            console.error("Error creating user:", error);
        }
    };

    return (
        <div className="create-user">
            <h1>Create User</h1>
            <form>
                <label>
                    First Name:
                    <input
                        type="text"
                        value={firstName}
                        onChange={(e) => setFirstName(e.target.value)}
                        required
                    />
                </label>
                <label>
                    Last Name:
                    <input
                        type="text"
                        value={lastName}
                        onChange={(e) => setLastName(e.target.value)}
                        required
                    />
                </label>
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
                <button type="button" onClick={handleCreateUser}>
                    Create User
                </button>
            </form>
        </div>
    );
}

export default CreateUserPage;
