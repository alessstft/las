
INSERT INTO users (email, password) VALUES
('user1@example.com', 'password1'),
('user2@example.com', 'password2');

INSERT INTO profiles (user_id, full_name, address) VALUES
(1, '���� ������', '��. ����, 1'),
(2, '���� ������', '��. �������, 42');

INSERT INTO categories (name) VALUES
('���������'),
('���������'),
('�������� ������');

INSERT INTO products (name, description, price, category_id) VALUES
('Lego Speed Champion', '�������� �����', 49.99, 1),
('Lego Truck', '������� ��������', 79.99, 2);

INSERT INTO orders (user_id) VALUES
(1), (2);

INSERT INTO order_items (order_id, product_id, quantity, price) VALUES
(1, 1, 2, 49.99),
(2, 2, 1, 79.99);

INSERT INTO tags (name) VALUES
('�������'),
('����������');

INSERT INTO product_tags (product_id, tag_id) VALUES
(1, 1),
(1, 2),
(2, 2);
