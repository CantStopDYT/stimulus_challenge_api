DELIMITER $$
CREATE DEFINER=`sc_user`@`%` PROCEDURE `get_stats`()
BEGIN

SELECT
	SUM(SmallBiz) as 'TotalSmallBiz',
    SUM(NonProfit) as 'TotalNonProfit',
    COUNT(*) as 'TotalPledges'
FROM Pledge;

END$$
DELIMITER ;
