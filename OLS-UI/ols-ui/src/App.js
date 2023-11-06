// libs
import React from 'react';
import { Fragment } from 'react';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';

// components
import { publicRoutes } from '~/routes';
import { DefaultLayout } from '~/components/Layouts';

function App() {
    return (
        <Router>
            <div className="App">
                <Routes>
                    {/* Viết map routes ở đây */}
                    {publicRoutes.map((route, index) => {
                        const Page = route.component;
                        // defualt layout
                        let Layout = DefaultLayout;
                        if (route.layout) {
                            Layout = route.layout;
                        } else if (route.layout === null) {
                            Layout = Fragment;
                        }
                        return (
                            <Route
                                key={index}
                                path={route.path}
                                element={
                                    <Layout>
                                        <Page />
                                    </Layout>
                                }
                            />
                        );
                    })}
                </Routes>
            </div>
        </Router>
    );
}

export default App;
