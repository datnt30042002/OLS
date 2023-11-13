// libs
import React from 'react';
import classNames from 'classnames/bind';

// components
import styles from './Home.module.scss';

const cx = classNames.bind(styles);

const Home = () => {
    return (
        // đang hardcode
        <main>
            <div>
                <p>Home</p>
                <p>+ Mục tiêu</p>
                <p>Show các khóa học mất phí</p>
                <p>Show các khóa học miễn phí</p>
                <p>Show danh sách các lộ trình</p>
                <p>Show các blogs cho người đọc</p>
                <p>+ Yêu cầu</p>
                <p>Nắm chắc cách vận dụng html css js</p>
                <p>trong 2 ngày</p>
                <p>học lại reactjs trong 1 ngày</p>
                <p>++ thời gian có 3 ngày</p>
            </div>
        </main>
    );
};

export default Home;
