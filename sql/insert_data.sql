INSERT INTO users (email, password) VALUES
('user1@example.com', 'password1'),
('user2@example.com', 'password2');

INSERT INTO profiles (user_id, full_name, address) VALUES
(1, 'Èâàí Èâàíîâ', 'óë. Ëåãî, 1'),
(2, 'Ïåòð Ïåòðîâ', 'ïð. Ìàøèíîê, 42');

INSERT INTO categories (name) VALUES
('Ñïîðòêàðû'),
('Ãðóçîâèêè'),
('Ãîíî÷íûå ìàøèíû');

INSERT INTO products (name, description, price, category_id) VALUES
('Lego Speed Champion', 'Ãîíî÷íûé áîëèä', 49.99, 1),
('Lego Truck', 'Áîëüøîé ãðóçîâèê', 79.99, 2);

INSERT INTO orders (user_id) VALUES
(1), (2);

INSERT INTO order_items (order_id, product_id, quantity, price) VALUES
(1, 1, 2, 49.99),
(2, 2, 1, 79.99);

INSERT INTO tags (name) VALUES
('íîâèíêà'),
('ðàñïðîäàæà');

INSERT INTO product_tags (product_id, tag_id) VALUES
(1, 1),
(1, 2),
(2, 2);
